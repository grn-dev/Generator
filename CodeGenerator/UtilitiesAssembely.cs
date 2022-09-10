using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace CodeGenerator
{
    public static class UtilitiesAssembely
    {
        public static string path = @"C:\Users\BAHARAN\source\repos\makatrip-gnror\Files\PropertyesClass.txt";
        public static string pathcs = @"C:\Users\BAHARAN\source\repos\makatrip-gnror\Files";

        public static string GhadirDll = @"C:\workshop\Ghadir\src\Ghadir.Domain\bin\Debug\net5.0\Ghadir.Domain.dll";
        public static string MakaTripDll = @"C:\workshop\makatrip\MakaTrip.Domain\bin\Debug\net5.0\MakaTrip.Domain.dll";



        public static IEnumerable<Type> Load_Assembly()
        {
            Assembly Assembly = Assembly.LoadFrom(GhadirDll);
            IEnumerable<Type> ListClasses = Assembly.GetTypes().Where(x => x.IsClass == true);
            return ListClasses;
        }

        public static string Getpropety(Type type)
        {
            string Pre = "";
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

        public static string PropertyForRegisterCommandHandler(Type type)
        {
            var Properties = type.GetProperties();
            string creatinpu = "";


            foreach (var item in Properties)
            {
                creatinpu += "request." + item.Name + "," + "\r\n";
            }

            int index = creatinpu.LastIndexOf(',');
            //CreatFile(path, "PropertyForRegiste.txt", creatinpu.Remove(index, 1)); 
            return creatinpu.Remove(index, 1);
        }
        public static string PropertyNONPrivet(Type type)
        {
            var Properties = type.GetProperties();
            string creatinpu = "";
            foreach (var item in Properties)
            {
                if (GetProprtyImpotant(item))
                {
                    creatinpu += "public " + item.PropertyTypeName() + " " + item.Name + "{ get; set; }" + "\r\n";
                }
            }
            //CreatFile(path, "PropertyNONPrivet.txt", creatinpu); 
            return creatinpu;
        }
        public static string PropertyCreate(Type type)
        {
            string creatinpu = "";
            var Properties = type.GetProperties();
            foreach (var item in Properties)
            {
                if (GetProprtyImpotant(item))
                {
                    creatinpu += item.PropertyType.Name.InstanceName() + ",";
                }
            }
            //CreatFile(path, "PropertyCreate.txt", creatinpu);
            int index = creatinpu.LastIndexOf(',');
            return creatinpu.Remove(index, 1);

        }

        public static string PropertyConstractor(Type type)
        {
            string creatinpu = "";
            var Properties = type.GetProperties();
            foreach (var item in Properties)
            {
                if (GetProprtyImpotant(item))
                {
                    creatinpu += item.PropertyTypeName() + " " + item.PropertyType.Name.InstanceName() + "," + "\r\n";
                }
            }
            //CreatFile(path, "PropertyCreate.txt", creatinpu); 
            int index = creatinpu.LastIndexOf(',');
            return creatinpu.Remove(index, 1);

        }
        public static string PropertyInsideConstractor(Type type)
        {

            string creatinpu = "";
            var Properties = type.GetProperties();
            foreach (var item in Properties)
            {
                if (GetProprtyImpotant(item))
                {
                    //creatinpu += item.PropertyTypeName() + " " + item.PropertyType.Name.InstanceName() + "," + "\r\n";
                    creatinpu += item.PropertyType.Name + " = " + item.PropertyType.Name.InstanceName() + ";" + "\r\n"; ;
                }
            }
            //CreatFile(path, "PropertyCreate.txt", creatinpu);
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
        public static string PropertyTypeName(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.IsEnum || propertyInfo.PropertyType.Name.Contains("DateTime"))
                return propertyInfo.PropertyType.Name;


            if (propertyInfo.PropertyType.Name.Contains("Int"))
            {
                return "int";
            }
            return propertyInfo.PropertyType.Name.ToLower();
        }

        public static bool GetProprtyImpotant(PropertyInfo item)
        {
            if (item.PropertyType.IsEnum || item.PropertyType.Name == "String" || (item.PropertyType.IsValueType && !AppSetting.IgnorFile().Contains(item.Name)))
                return true;

            return false;

        }
        public static bool GetProprtyImpotantSetEnum()
        {
            var Assemblyes = GetTypesByAssemblyName("Ghadir.Application");


            foreach (var item3 in Assemblyes)
            {
                var asdasd = item3.GetTypeInfo().DeclaredMembers;
                foreach (var VmVM in asdasd)
                {
                    foreach (var Properti in VmVM.GetType().GetProperties())
                    {
                        if (Properti.PropertyType.IsEnum)
                        {
                            //Set [EnumDataType(typeof(WellConsumption))]
                        }
                    }
                }
            }
            return false;

        }

        private static List<Type> GetTypesByAssemblyName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new List<Type>();

            return Assembly.Load(name)
               .GetTypes()
               .Where(x => x.Name.Contains("ViewModel"))
               .ToList();
        }

    }
}
