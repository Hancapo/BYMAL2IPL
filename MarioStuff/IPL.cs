using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYMAL2IPL
{
    public class IPL
    {

        public List<Instance> IPLinstances { get; set; } = new();

        public void AddInstanceToIPL(Instance inst)
        {
            IPLinstances.Add(inst);
        }


        public void ExportIPL(string exportpath)
        {
            StringBuilder sb = new();
            if (IPLinstances.Count > 0)
            {
                sb.AppendLine("inst");
                foreach (Instance inst in IPLinstances)
                {
                    sb.AppendLine($"{inst.Id}, {inst.ModelName}, {inst.Interior}, {inst.Position.X}, {inst.Position.Y}, {inst.Position.Z}, {inst.Rotation.X}, {inst.Rotation.Y}, {inst.Rotation.Z}, {inst.Rotation.W}, {inst.LOD}");
                }
                sb.AppendLine("end");

            }

            File.WriteAllText(exportpath + "/course_muunt.ipl", sb.ToString());
        }

    }
}
