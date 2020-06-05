using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Actor = new HashSet<Actor>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string DirectedBy { get; set; }
        public int Budget { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double? Rating { get; set; }

        public virtual ICollection<Actor> Actor { get; set; }

        public override string ToString()
        {
            return this.Id + ". " + this.Title + ", " + this.DirectedBy + ", " + this.Budget.ToString() + ", " + this.ReleaseDate.ToString() +", " + this.Rating + ".";
        }
    }
}
