using Syroot.NintenTools.Byaml.Dynamic;

dynamic coursefile = ByamlFile.Load("sd");

dynamic amigo = coursefile["Obj"][2];