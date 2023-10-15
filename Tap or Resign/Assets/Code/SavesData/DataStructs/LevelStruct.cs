using System;
using System.Collections.Generic;

namespace Code.SavesData.DataStructs
{
    [Serializable]
    public struct LevelStruct
    {
        public string levelName;
        public byte difficulty;
        public LogoStruct logo;
        public byte playerNumber; //number of players
        public List<Tuple<float, float>> StartPositions; //the players spawn here
        public List<Tuple<int, Tuple<float, float>>> Obstacles; //contains index and 2D coords
        public List<Tuple<int, Tuple<float, float>>> Triggers;
        
        [Serializable]
        public struct LogoStruct
        {
            public int background;
            public int ground;
            public int groundItem;
            public int flyingItem;
        }

        //default level when you create a new level
        public static LevelStruct EmptyLevel = new LevelStruct()
        {
            levelName = "defaultName",
            difficulty = 126,
            logo = new LogoStruct()
            {
                background = 0,
                ground = 0,
                groundItem = 0,
                flyingItem = 0
            },
            Obstacles = new List<Tuple<int, Tuple<float, float>>>(),
            Triggers = new List<Tuple<int, Tuple<float, float>>>(),
            playerNumber = 1,
            StartPositions = new List<Tuple<float, float>>()
        };
    }
}