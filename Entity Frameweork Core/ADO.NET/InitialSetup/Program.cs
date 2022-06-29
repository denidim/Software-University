using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace InitialSetup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SqlConnectionString = "Server=.;Database=minionsDB;User Id=sa;Password=mssqlDB1;";

            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();
            }
            
        }
        //9. Increase Age Stored Procedure 
        private static void UseStoredProcedure(SqlConnection connection)
        {
            const string usp_Query = @"exec usp_GetOlder @Id";
            const string selecrQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

            int id = int.Parse(Console.ReadLine());

            using (var cmd = new SqlCommand(usp_Query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SqlCommand(selecrQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]} years old.");
                }
            }
        }

        //8. Increase Minion Age
        private static void IncreaseMinionAge(SqlConnection connection)
        {
            const string updateQuery = @"UPDATE Minions
                                       SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                           WHERE Id = @Id";

            const string slectQuery = @"SELECT Name, Age FROM Minions";

            int[] id = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            using (var cmd = new SqlCommand(updateQuery, connection))
            {
                for (int i = 0; i < id.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@Id", i);

                    cmd.ExecuteNonQuery();
                }
            }
            using (var cmd = new SqlCommand(slectQuery, connection))
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }
        }

        //7. Print All Minion Names
        private static void PrintAllMinionNames(SqlConnection connection)
        {
            const string selectMinionsNameQuery = @"SELECT Name FROM Minions";

            var minions = new List<string>();

            using (var cmd = new SqlCommand(selectMinionsNameQuery, connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    minions.Add(reader.GetString(0));
                }
            }


            if (minions.Count / 2 % 2 == 0)//even
            {
                for (int i = 0; i < minions.Count / 2; i++)
                {
                    Console.WriteLine(minions[i]);
                    Console.WriteLine(minions[minions.Count - 1 - i]);
                }
            }
            else
            {
                for (int i = 0; i < minions.Count / 2; i++)
                {
                    Console.WriteLine(minions[i]);
                    Console.WriteLine(minions[minions.Count - 1 - i]);
                }
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }

        //6. *Remove Villain 
        private static void RemoveVillain(SqlConnection connection)
        {
            string id = Console.ReadLine();

            const string deleteMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
                                                               WHERE VillainId = @villainId";

            const string deleteVillainsQuery = @"DELETE FROM Villains
                                                        WHERE Id = @villainId";

            var name = ExtractName(connection, id);
            if (name == null)
            {
                Console.WriteLine("No such villain was found.");
            }
            else
            {
                int deletedMinionsCount = Delete(connection, id, deleteMinionsVillainsQuery);
                Delete(connection, id, deleteVillainsQuery);
                Console.WriteLine($"{name} was deleted.");

                if (deletedMinionsCount == 0)
                {
                    Console.WriteLine("0 minions were relesed");
                }
                else
                {
                    Console.WriteLine($"{deletedMinionsCount} minions were relesed");
                }
            }
        }

        private static int Delete(SqlConnection connection, string id, string query)
        {
            using (var cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@villainId", id);

                return cmd.ExecuteNonQuery();
            }
        }

        private static string ExtractName(SqlConnection connection, string id)
        {
            
            const string evilNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";

            using (var cmd = new SqlCommand(evilNameQuery, connection))
            {
                cmd.Parameters.AddWithValue("villainId", id);

                return (string)cmd.ExecuteScalar();
            }
        }

        //5. Change Town Names Casing
        private static void ChangeTownNamesCasingd(SqlConnection connection)
        {
            string country = Console.ReadLine();
            int changeNames = ChangeNames(connection, country);
            if (changeNames > 0)
            {
                var extracted = ExtractNames(connection, country);
                if (extracted != null)
                {
                    Console.WriteLine($"[{string.Join(", ", extracted)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
            else
            {
                Console.WriteLine("No town names were affected.");
            }
        }

        private static List<string> ExtractNames(SqlConnection connection,string country)
        {
            var names = new List<string>();
            string selectChangedNamesQuery = @"SELECT t.Name 
                                                        FROM Towns as t
                                                            JOIN Countries AS c ON c.Id = t.CountryCode
                                                                WHERE c.Name = @countryName";
            using (var command = new SqlCommand(selectChangedNamesQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", country);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add((string)reader[0]);
                    }
                }
            }
            return names;
        }

        private static int ChangeNames(SqlConnection connection, string country)
        {
            const string changeNameQuery = @"UPDATE Towns
                                            SET Name = UPPER(Name)
                                                WHERE CountryCode = 
                                                    (SELECT c.Id FROM Countries AS c
                                                        WHERE c.Name = @countryName)";
            using (var command = new SqlCommand(changeNameQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", country);
                return command.ExecuteNonQuery();
            }
        }




        //4.add minion
        private static void AddMinion(SqlConnection connection)
        {
            string[] minionInput = Console.ReadLine().Split(" ");
            string minionName = minionInput[1];
            int minionAge = int.Parse(minionInput[2]);
            string minionTown = minionInput[3];

            string villaintName = Console.ReadLine().Split(" ")[1];

            int villaintId = ExtractVillaintID(connection, villaintName);

            int minionTownId = ExtractMinionTownID(connection, minionTown);

            int minionId = InsertMinionAndExtractID(connection, minionName, minionAge, minionTownId);

            MakeServant(connection, minionId, villaintId);

            Console.WriteLine($"Successfully added {minionName} to be minion of {villaintId}.");
        }

        private static void MakeServant(SqlConnection connection, int minionId, int villaintId)
        {
            const string insertQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            using (var command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId",villaintId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();
            }
        }

        private static int InsertMinionAndExtractID(SqlConnection connection, string minionName, int minionAge, int? minionTownId)
        {
            const string insertMinionQuery = @"INSERT INTO Minions(Name, Age, TownId) VALUES(@name, @age, @townId)";
            const string minionIdQuery = @"SELECT Id FROM Minions WHERE Name = @Name";

            using (var insertCommand = new SqlCommand(insertMinionQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@name", minionName);
                insertCommand.Parameters.AddWithValue("@age", minionAge);
                insertCommand.Parameters.AddWithValue("@townId", minionTownId);
                insertCommand.ExecuteNonQuery();
            }

            using(var idCommand = new SqlCommand(minionIdQuery, connection))
            {
                idCommand.Parameters.AddWithValue("@Name", minionName);
                return (int)idCommand.ExecuteScalar();
            }
        }

        private static int ExtractMinionTownID(SqlConnection connection, string townName)
        {
            const string townIdQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
            const string insertTownQuery = @"INSERT INTO Towns(Name) VALUES(@townName)";

            using(var townIdCommand = new SqlCommand(townIdQuery, connection))
            {
                townIdCommand.Parameters.AddWithValue("@townName", townName);
                //In case the town of the minion is not in the database, insert it as well
                int? townId = (int)townIdCommand.ExecuteScalar();

                if(townId == null)
                {
                    using(var insertTownCommand = new SqlCommand(insertTownQuery, connection))
                    {
                        insertTownCommand.Parameters.AddWithValue("@townName", townName);

                        insertTownCommand.ExecuteNonQuery();
                    }
                    Console.WriteLine($"Town {townName} was added to the database.");
                }
                return (int)townIdCommand.ExecuteScalar();
            }
        }

        private static int ExtractVillaintID(SqlConnection connection, string villaintName)
        {
            const string villaintIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";

            using (var villainIdCommand = new SqlCommand(villaintIdQuery, connection))
            {
                villainIdCommand.Parameters.AddWithValue("@Name", villaintName);

                int? villaintId = (int)villainIdCommand.ExecuteScalar();
                //In case the villain is not present in the database, add him too with a default evilness factor of "evil".
                if (villaintId == null)
                {
                    string insertVillantQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                    using (var insertVillaintCommand = new SqlCommand(insertVillantQuery, connection))
                    {
                        insertVillaintCommand.Parameters.AddWithValue("@villainName", villaintName);

                        insertVillaintCommand.ExecuteNonQuery();
                    }
                    Console.WriteLine($"Villain {villaintName} was added to the database.");
                }
                return (int)villainIdCommand.ExecuteScalar();
            }
        }

        //3.minion names
        private static void MinionNames(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());
            string villanNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";

            using (var villainNameCommand = new SqlCommand(villanNameQuery, connection))
            {
                villainNameCommand.Parameters.AddWithValue("@Id", id);

                var villantName = (string)villainNameCommand.ExecuteScalar();

                if (villantName != null)
                {
                    Console.WriteLine($"Villain: {villantName}");

                    string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                    using (var minnionsCommand = new SqlCommand(minionsQuery, connection))
                    {
                        minnionsCommand.Parameters.AddWithValue("@Id", id);

                        var minnions = minnionsCommand.ExecuteScalar();
                        if (minnions != null)
                        {
                            using (var reader = minnionsCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("no minions");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
            }
        }

        //2. Villain Names
        private static void GetVillainNames(SqlConnection connection)
        {
            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v 
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                GROUP BY v.Id, v.Name 
                                HAVING COUNT(mv.VillainId) > 3 
                                ORDER BY COUNT(mv.VillainId)";

            using (var comd = new SqlCommand(query, connection))
            {
                using (var reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0];
                        var value = reader[1];
                        Console.WriteLine($"{name} - {value}");
                    }
                }
            }
        }

        //01.Initial Setup
        private static void InitialSetup(SqlConnection connection)
        {
            string createDB = "create database MinionsDB";

            ExecuteNonQuery(connection, createDB);

            var createTablesQueries = GetCreateSql();

            var insertInTablesQueries = GetInsertSql();

            foreach (var item in createTablesQueries)
            {
                ExecuteNonQuery(connection, item);
            }

            foreach (var item in insertInTablesQueries)
            {
                ExecuteNonQuery(connection, item);
            }
        }

        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using var cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        private static string[] GetCreateSql()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };
            return result;
        }

        private static string[] GetInsertSql()
        {
            var result = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
            };
            return result;
        }
    }
}
