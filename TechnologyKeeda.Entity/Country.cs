﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyKeeda.Entity
{ 
    //Country----------(*)State
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default Country";
        //Navigation property
        public ICollection<State> States { get; set; } = new HashSet<State>();
    }
}
