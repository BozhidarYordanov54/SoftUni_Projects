﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Wizard
{
    public class DarkWizard : Wizard
    {
        public DarkWizard(string name, int level) : base(name, level) 
        {
            Username = name;
            Level = level;
        }
    }
}
