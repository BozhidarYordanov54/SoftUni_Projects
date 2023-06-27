﻿using System;
using UniversityCompetition.Exceptions;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;
        protected Subject(int id, string name, double rate)
        {
            Id = id;
            Name = name;
            Rate = rate;
        }
        public int Id
        {
            get { return id; }
            private set
            { 
                id = value;
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    
                }
            }
        }
        public double Rate
        {
            get => rate;
            private set 
            {
                rate = value;
            }
        }
    }
}
