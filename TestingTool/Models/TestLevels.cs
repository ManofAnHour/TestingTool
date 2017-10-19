using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingTool.Models
{
    public class TestLevels
    {
        public List<FirstLevel> FirstLevel;

        public class TestStructures
        {
            public string Name { get; set; }
            public string ShortName { get; set; }
            public Guid id { get; set; }
            public Guid Parent_IDNumber { get; set; }
            public int Level = 0;
            public int status;
        }
    }

    public class FirstLevel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<SecondLevels> Children;
    }
    public class SecondLevels
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<ThirdLevels> Children;
    }
    public class ThirdLevels
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<FourthLevels> Children;
    }
    public class FourthLevels
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<FifthLevels> Children;
    }
    public class FifthLevels
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<SixthLevels> Children;
    }
    public class SixthLevels
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
    public class Level
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        List<Level> Children;
    }

    public class Test_Level
    {
        public Level First;
        public Level Second;
        public Level Third;
        public Level Fourth;
        public Level Fifth;
        public Level Sixth;
    }


    public class Application
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Guid id { get; set; }
    }
}