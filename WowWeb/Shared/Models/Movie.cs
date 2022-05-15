using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowWeb.Shared
{
    public class Movie
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public Genre Genre { get; set; }
    }
}
