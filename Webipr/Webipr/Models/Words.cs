using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webipr.Models
{
    //Checks model
    public class Words
    {
        //Id of check
        public int WId { get; set; }
        //Main word of check
        public string Text { get; set; }
        //Foreign key for check
        public int? ChId { get; set; }
        //Object type check class
        public Checks Check { get; set; }
    }
}