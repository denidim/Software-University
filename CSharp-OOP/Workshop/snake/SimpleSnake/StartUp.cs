namespace SimpleSnake
{
    using Core;
    using GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            //if played on macOS commnt line 43 and 45 in Food.cs 
            //and line 14 in StartUp.cs

            ConsoleWindow.CustomizeConsole();//commnet this line for macOS

            Wall wall = new Wall(40, 10);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
