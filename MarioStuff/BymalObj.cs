using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BYMAL2IPL
{
    public class BymalObj
    {
        public string? ObjName { get; set; }
        public int ObjId { get; set; }
        public Vector3 EulerRotation { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Scale { get; set; }
    }
}
