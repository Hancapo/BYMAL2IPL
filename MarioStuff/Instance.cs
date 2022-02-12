using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BYMAL2IPL
{
    public class Instance
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Interior { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public int LOD { get; set; }
    }
}
