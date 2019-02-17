using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannersCounter
{
    public class Banner
    {
        public Banner(int id, int count)
        {
            Id = id;
            DisplayCount = count;
        }
        public int Id { get; set; }
        public int DisplayCount { get; set; }
    }
}
