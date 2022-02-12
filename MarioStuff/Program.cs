using BYMAL2IPL;
using Syroot.Maths;
using Syroot.NintenTools.Byaml.Dynamic;
using System.Numerics;
using Vector3 = System.Numerics.Vector3;
using Syroot.BinaryData;
using Vector4 = System.Numerics.Vector4;

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;


List<BymalObj> BymalObjsList = new List<BymalObj>(); 

Console.WriteLine("Insert path of your .csv with Objsdata");
string csvpath = Console.ReadLine();

Console.Clear();

MK8ObjCSV ms = new();

ms.CSVtoDictionary(csvpath);


Console.WriteLine("Insert path of your .byaml file");
string bymalpath = Console.ReadLine();

Console.Clear();


dynamic bymalfile = ByamlFile.Load(bymalpath, true, ByteOrder.LittleEndian);


List<dynamic> BymalObjs = bymalfile["Obj"];


foreach (var item in BymalObjs)
{

    Console.WriteLine($"Reading Objs {item["ObjId"]}");

    int ItemId = Convert.ToInt32(item["ObjId"]);
    Vector3 GetRotation = new();
    
    GetRotation.X = Algebra.RadiansToDegrees(Convert.ToSingle(item["Rotate"]["Y"])); //de X a Y
    GetRotation.Y = Algebra.RadiansToDegrees(Convert.ToSingle(item["Rotate"]["X"])); //de Y a X
    GetRotation.Z = Algebra.RadiansToDegrees(Convert.ToSingle(item["Rotate"]["Z"]));

    Vector3 GetPosition = new();

    GetPosition.X = Convert.ToSingle(item["Translate"]["Y"]);
    GetPosition.Y = Convert.ToSingle(item["Translate"]["X"]);
    GetPosition.Z = Convert.ToSingle(item["Translate"]["Z"]);

    Vector3 GetScale = new();

    GetScale.X = Convert.ToSingle(item["Scale"]["X"]);
    GetScale.Y = Convert.ToSingle(item["Scale"]["Y"]);
    GetScale.Z = Convert.ToSingle(item["Scale"]["Z"]);

    BymalObj bobj = new() {
        ObjId = ItemId,
        ObjName = ms.MK8Objs.GetValueOrDefault(ItemId),
        EulerRotation = GetRotation,
        Position = GetPosition,
        Scale = GetScale
    };


    BymalObjsList.Add(bobj);

}

IPL ipl = new();


foreach (var item2 in BymalObjsList)
{
    Instance inst = new();

    if (item2.ObjName == null)
    {
        item2.ObjName = "null";
    }

    inst.Id = item2.ObjId;
    inst.ModelName = item2.ObjName;
    inst.Interior = 1;
    inst.Rotation = Quaternion.CreateFromYawPitchRoll(item2.Position.X, item2.Position.Y, item2.Position.Z);
    inst.Position = item2.Position;
    inst.LOD = 1;

    ipl.AddInstanceToIPL(inst);
}

Console.WriteLine("Insert path for IPL exporting");
string iplpath = Console.ReadLine();    

ipl.ExportIPL(iplpath);
