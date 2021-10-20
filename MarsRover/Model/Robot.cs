using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Model
{
    public class Robot
    {
        public int x { get; set; } // robot x konumu
        public int y { get; set; } // robot y konumu
        public string direction { get; set; } // robot yönü
        public string movements { get; set; } // robot hareketleri
        public bool outOfArea { get; set; } // robot alan dışına çıkıtığında true olacak
    }
}
