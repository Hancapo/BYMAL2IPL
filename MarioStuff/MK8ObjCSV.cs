using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYMAL2IPL
{
    public class MK8ObjCSV
    {
        public Dictionary<int, string> MK8Objs { get; set; } = new();



        public void CSVtoDictionary(string filename)
        {
            string[] csvlines = File.ReadAllLines(filename);
            foreach (string line in csvlines)
            {
                if (line.StartsWith("id;objectname")) { continue; }
                int ObjsId = Convert.ToInt32(line.Split(';')[0]);
                string ObjsName = line.Split(';')[1];
                MK8Objs.Add(ObjsId,ObjsName);
            }
        }



    }
}
