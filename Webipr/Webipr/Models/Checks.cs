using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webipr.Models
{
    //Checks model
    public class Checks
    {
        //Id of check
        public int CId { get; set; }
        //Main word of check
        public string Word { get; set; }
        //Words collection
        public ICollection<Words> Words { get; set; }
        //Check method
        public Checks()
        {
            Words = new List<Words>();
        }
    }
}