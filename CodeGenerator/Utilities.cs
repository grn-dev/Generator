using PluralizeService.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeGenerator
{
    public static class Utilities
    {
        public static string path_Ghabli = @"C:\Users\BAHARAN\source\repos\CodeGenerator\Files\PropertyesClass.txt";
        public static string pathaa = @"C:\Users\BAHARAN\source\repos\CodeGenerator\CodeGenerator\0PropertyesClass.txt";
        public static string path = @"D:\VisualStudioProject\CodeGeneratorV6\CodeGenerator\CodeGenerator\0PropertyesClass.txt";
        public static string pathcs = @"C:\Users\BAHARAN\source\repos\CodeGenerator\Files";
        public static string pathcs_sddf = @"C:\Users\BAHARAN\source\repos\CodeGenerator\Files\AgriculturalInformation.cs";
        public static string GhadirDll = @"C:\workshop\Ghadir\src\Ghadir.Domain\bin\Debug\net5.0\Ghadir.Domain.dll";
        public static string Ghadir = @"C:\Users\BAHARAN\source\repos\CodeGenerator\Files\Ghadir.Domain.dll";
        public static string ertref = @"C:\Users\BAHARAN\source\repos\CodeGenerator\Files\ref\Ghadir.Domain.dll";

        public static List<T> GetFilePlugins<T>(string filename)
        {
            List<T> ret = new List<T>();
            if (File.Exists(filename))
            {
                Type typeT = typeof(T);
                Assembly ass = Assembly.LoadFrom(filename);
                foreach (Type type in ass.GetTypes())
                {
                    if (!type.IsClass || type.IsNotPublic) continue;
                    if (typeT.IsAssignableFrom(type))
                    {
                        T plugin = (T)Activator.CreateInstance(type);
                        ret.Add(plugin);
                    }
                }
            }
            return ret;
        }
        public static List<T> GetDirectoryPlugins<T>(string dirname)
        {
            Assembly Assembly = Assembly.LoadFrom(GhadirDll);
            //var list = Assembly.GetTypes().Where(x => x.IsClass == true && x.IsSubclassOf(BaseModel));









            Assembly mscorlib = typeof(string).Assembly;
            foreach (Type type in mscorlib.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }
            //var  typeasd = aserts.GetTypes();

            //var serviceAgentAssembly = System.Reflection.Assembly.LoadFrom(string.Format(CultureInfo.InvariantCulture, @"{0}\{1}", assemblyPath, assemblyName));

            //foreach (Type objType in serviceAgentAssembly.GetTypes())
            //{
            //    //further loops to get the method
            //    //your code to ivoke the function
            //}


            Type objectType = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                               from type in asm.GetTypes()
                               where type.IsClass
                               select type).Single();
            object obj = Activator.CreateInstance(objectType);

            //Type typeass = ass.GetType("AgriculturalInformation");
            //Assembly asm = typeof(TestClass).Assembly;


            List<T> ret = new List<T>();
            string[] dlls = Directory.GetFiles(dirname, "*.cs");
            foreach (string dll in dlls)
            {
                List<T> dll_plugins = GetFilePlugins<T>(Path.GetFullPath(dll));
                ret.AddRange(dll_plugins);
            }
            return ret;
        }
        public static void Load_a_text_file_as_a_class()
        {
            Type type = Type.GetType("Namespace.MyClass, MyAssembly");

            Assembly Assembly = Assembly.LoadFrom(GhadirDll);
            var list = Assembly.GetTypes().Where(x => x.IsClass == true);




            //var sda = GetDirectoryPlugins<Type>(pathcs);
            string creatinpu = "";
            string[] lines = new string[1000];

            if (File.Exists(pathcs))
            {
                lines = File.ReadAllLines(pathcs);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    lines[i] = lines[i].Replace("        ", "");
                    lines[i] = lines[i].Replace("\t", "");
                    var Splitline = lines[i].Split(" ");

                    creatinpu += "request." + Splitline[2] + "," + "\r\n";

                }
                //CreatFile(path,"classProRequests", creatinpu); 

            }
            int index = creatinpu.LastIndexOf(',');
            var sdfsdf = creatinpu.Remove(index, 1);
            //return Type;
        }
        public static string getpropety(Type type, string Pre = "")
        {
            var dfdfdfvxcv = type.GetProperties();
            string sadasd = "(" + "\n";
            foreach (var fieldInfo in dfdfdfvxcv)
            {
                if (fieldInfo.PropertyType.Name.Contains("Int"))
                {
                    sadasd += Pre + "int" + " " + fieldInfo.Name + "," + "\n";
                }
                else
                {
                    sadasd += Pre + fieldInfo.PropertyType.Name.ToLower() + " " + fieldInfo.Name + "," + "\n";
                }

            }
            sadasd = sadasd.Remove(sadasd.Length - 2);
            sadasd += "\n";
            sadasd += ")";


            return sadasd;
        }

        public static string getpropetyCoomad(Type type, string Pre = "", string suffix = "")
        {
            var dfdfdfvxcv = type.GetProperties();
            string sadasd = "\n";
            foreach (var fieldInfo in dfdfdfvxcv)
            {
                if (fieldInfo.PropertyType.Name.Contains("Int"))
                {
                    sadasd += Pre + "int" + " " + fieldInfo.Name + suffix + "\n";
                }
                else
                {
                    sadasd += Pre + fieldInfo.PropertyType.Name.ToLower() + " " + fieldInfo.Name + suffix + "\n";
                }

            }
            sadasd += "\n";


            return sadasd;
        }

        public static string InstanceName(this string ClassMname)
        {
            return ClassMname.Substring(0, 1).ToLower() + ClassMname.Substring(1, ClassMname.Length - 1);
        }

        public static string ContollerName(this string ClassMname)
        {
            return PluralizationProvider.Pluralize(ClassMname);
        }

        public static string PropertyForRegisterCommandHandler(string input = "request")
        {

            string creatinpu = "";
            string[] lines = new string[1000];

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    lines[i] = lines[i].Replace("        ", "");
                    lines[i] = lines[i].Replace("\t", "");
                    var Splitline = lines[i].Split(" ");

                    //creatinpu += "request." + Splitline[2] + "," + "\r\n";
                    creatinpu += SetSpaceLine(i, input + "." + Splitline[2] + "," + "\r\n", "\t\t\t\t\t");// ;

                }
                //CreatFile(path,"classProRequests", creatinpu); 

            }
            int index = creatinpu.LastIndexOf(',');
            return creatinpu.Remove(index, 1);
        }
        public static string PropertyNONPrivet(string Pre = "\t\t")
        {
            string creatinpu = "";
            string[] lines = new string[1000];

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    lines[i] = lines[i].Replace("        ", "");
                    lines[i] = lines[i].Replace("\t", "");
                    var Splitline = lines[i].Replace("private ", "");

                    //creatinpu += Splitline + "\r\n";
                    creatinpu += SetSpaceLine(i, Splitline + "\r\n", Pre);// ;



                }
                //CreatFile(path, "PropertyNONPrivetdsd.txt", creatinpu);

            }
            return creatinpu;
        }
        public static string PropertyCreate()
        {
            string creatinpu = "";
            string[] lines = new string[1000];

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    lines[i] = lines[i].Replace("        ", "");
                    lines[i] = lines[i].Replace("\t", "");
                    var Splitline = lines[i].Split(" ");

                    creatinpu += Splitline[2].InstanceName() + ",";

                }
                //CreatFile(path, "PropertyCreate.txt", creatinpu);

            }
            int index = creatinpu.LastIndexOf(',');
            return creatinpu.Remove(index, 1);

        }
        public static string GetPropertyesclass()
        {
            string creatinpu = "";
            string[] lines = new string[1000];

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    lines[i] = lines[i].Replace("        ", "");
                    lines[i] = lines[i].Replace("\t", "");
                    var Splitline = lines[i].Split(" ");

                    creatinpu += Splitline[1] + " " + Splitline[2].InstanceName() + "," + "\r\n"; ;

                }
                //CreatFile(path, "Dick.txt", creatinpu);

            }
            return "";
        }
        public static string PropertyConstractor()
        {
            string creatinpu = "";
            string[] lines = new string[1000];

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    lines[i] = lines[i].Replace("        ", "");
                    lines[i] = lines[i].Replace("\t", "");
                    var Splitline = lines[i].Split(" ");


                    //creatinpu += "\t\t\t" + Splitline[1] + " " + Splitline[2].InstanceName() + "," + "\r\n";
                    creatinpu += SetSpaceLine(i, Splitline[1] + " " + Splitline[2].InstanceName() + "," + "\r\n", "\t\t\t\t\t");

                }
                //CreatFile(path, "PropertyCreate.txt", creatinpu);

            }
            int index = creatinpu.LastIndexOf(',');
            return creatinpu.Remove(index, 1);

        }
        public static string SetSpaceLine(int line, string Format, string Pre)
        {
            if (line == 0)
                return Format;

            return Pre + Format;

        }
        public static string PropertyInsideConstractor()
        {
            string creatinpu = "";
            string[] lines = new string[1000];

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    lines[i] = lines[i].Replace("        ", "");
                    lines[i] = lines[i].Replace("\t", "");
                    var Splitline = lines[i].Split(" ");

                    //creatinpu += Splitline[2] + " = " + Splitline[2].InstanceName() + ";" + "\r\n"; 

                    creatinpu += SetSpaceLine(i, Splitline[2] + " = " + Splitline[2].InstanceName() + ";" + "\r\n", "\t\t\t");


                }
                //CreatFile(path, "PropertyCreate.txt", creatinpu);

            }
            return creatinpu;

        }
        public static void CreatFile(string path, string NameWithPasVand, string Content)
        {
            FileStream stream = null;
            stream = new FileStream(path + NameWithPasVand, FileMode.OpenOrCreate);

            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.WriteLine(Content);
            }
        }
        public static void FixRroFile()
        {
            string pathAutoMapper01 = "C:\\workshop\\makatrip\\MakaTrip.Application\\AutoMapper";
            string pathAutoMapper = @"C:\workshop\uaa\Identity\IdentityServer.Application\AutoMapper";
            DirectoryInfo info = new DirectoryInfo(pathAutoMapper);
            FileInfo[] infos = info.GetFiles();
            foreach (FileInfo f in infos)
            {
                File.Move(f.FullName, f.FullName.Replace("Rrofile.cs", "Profile.cs"));
            }
        }
        public static string AddSpace()
        {
            string CustomeSpace = "";
            for (var i = 0; i < 2; i++)
            {
                CustomeSpace += "\r\n";
            }
            CustomeSpace += "//-------------------------------------------------";
            for (var i = 0; i < 2; i++)
            {
                CustomeSpace += "\r\n";
            }
            return CustomeSpace;
        }
        public static string ReadDocument(string path)
        {
            string SorceCodeBefor = "";
            var lines = File.ReadAllLines(path);

            for (var i = 0; i < lines.Length; i += 1)
            {
                SorceCodeBefor += lines[i] + "\r\n";
            }
            return SorceCodeBefor;
        }
        public static string FixBackSlash(string path)
        {
            path = path.Replace(@"\\", @"\");
            path = path.Replace(@"\\\", @"\");
            path = path.Replace(@"\\\\", @"\");

            return path;
        }

    }
}
