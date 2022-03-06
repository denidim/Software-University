using System;
using military.Enumerations;
using military.Interfaces;

namespace military.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }

        public string CodeName { get; set; }
        

        public MissionStateEnum MissionState { get; set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
