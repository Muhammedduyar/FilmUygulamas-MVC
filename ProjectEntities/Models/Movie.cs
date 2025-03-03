using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntities.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public string MovieDescription { get; set; }
        public DateTime? ReleasedDate { get; set; }//nullable kontrolü
        public bool isWatched { get; set; }
        public string Image { get; set; }


    }
}
