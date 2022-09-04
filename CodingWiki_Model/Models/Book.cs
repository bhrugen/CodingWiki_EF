using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Book
    {
        public int IDBook { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }
}
