using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public string Nation { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public override string ToString()
        {
            return this.Id + ". " + this.Name + ", " + this.Born.ToString() + ", " + this.Nation;
        }
    }
}
