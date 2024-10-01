using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    public class pekaru
    {
        public static List<pekaru> pekaruk = new List<pekaru>();

        public int id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    }
}
