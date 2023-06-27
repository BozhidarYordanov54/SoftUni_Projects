﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Knight
{
    public class Knight : Hero
    {
        public Knight(string name, int level) : base(name, level) 
        {
            Username = name;
            Level = level;
        }
    }
}
