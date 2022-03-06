using System;
using military.Enumerations;
using military.Models;

namespace military.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; set; }
        public MissionStateEnum MissionState { get; set; }
    }
}
