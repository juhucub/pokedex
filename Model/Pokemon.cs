using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// actual card object
namespace WebApplication1.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }

    }
}