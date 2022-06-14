﻿using System.Collections.Generic;

namespace Kol2_example.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }
    }
}
