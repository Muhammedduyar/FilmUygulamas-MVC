using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDto
{
    public class MovieDto
    {
        public int  Id { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public string MovieDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool isWatch { get; set; }
        public string ImageMovie { get; set; }


    }
}
