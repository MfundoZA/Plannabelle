using System;
using System.Collections.Generic;
using System.Text;

namespace PlannabelleClassLibrary.Models
{
    public class Module
    {
        // Properties
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        // Constructors
        public Module()
        {

        }

        public Module(string code, string name, int credits)
        {
            Code = code;
            Name = name;
            Credits = credits;
        }

        public Module(int id, string code, string name, int credits)
        {
            Id = id;
            Code = code;
            Name = name;
            Credits = credits;
        }
    }
}
