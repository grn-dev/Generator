using System;
using System.IO;

namespace CodeGenerator
{
    public static class MethodClass
    {
        public static string pathMethodClass = @".Domain\Models\";
        public static ClassInfo Creat_MethodClass(InfoRegisterClassInput input)
        {

            string ForAggragte = String.IsNullOrEmpty(input.AggregateName) ? input.EntityName : input.AggregateName;

            string _surce = "";
            string _surceMainCrreated = "";
            var classinfo = new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + ".cs",
                //Path = @"C:\\workshop\Host\Host.Domain\Models\Facility\InstallmentMaturity\InstallmentMaturityFeeSnapshot",
                Path = input.PathSolotion + "\\" + input.SolutionName + pathMethodClass + "\\" + ForAggragte + "\\",

            };
            string SourceBefor = "";
            string fileName1 = classinfo.Path + "\\" + classinfo.ClassName;
            if (File.Exists(fileName1))
            {
                SourceBefor = Utilities.ReadDocument(fileName1);
                File.Delete(fileName1);
            }

            string constracotrs = $@" 
        private {input.EntityName}({Utilities.PropertyConstractor()})
        {{
           {Utilities.PropertyInsideConstractor()}
        }} 
        private {input.EntityName}(){{}}";

            string methods = $@" 
        public static {input.EntityName} Create({Utilities.PropertyConstractor()})
        {{
            return new {input.EntityName}({Utilities.PropertyCreate()});
        }} 
        public void Update({Utilities.PropertyConstractor()})
        {{
            {Utilities.PropertyInsideConstractor()}
        }} 
        public static {input.EntityName} DeleteRegistered(int id)=> new {input.EntityName}() {{ Id = id }};  
";




            var SourceSplitacoladBaz = SourceBefor.Split("{");

            string temp_surce = "";
            for (int i = 0; i < SourceSplitacoladBaz.Length; i++)
            {
                if (i == 2)
                {
                    temp_surce += constracotrs;
                }
                temp_surce += SourceSplitacoladBaz[i] + "{";

            }


            var SourceSplitacoladBaste = temp_surce.Split("}");

            for (int i = 0; i < SourceSplitacoladBaste.Length; i++)
            {
                if (i == SourceSplitacoladBaste.Length - 2)
                {
                    _surce += methods;
                }
                _surce += "}" + SourceSplitacoladBaste[i];
                //_surce += "}" + SourceSplitacoladBaste[i];

            }
            _surce = _surce.Replace("}using", "using");
            _surce = _surce.Replace("() { Id = id };  \r\n}\r\n}\r\n{", "() { Id = id };  \r\n}\r\n}\r\n");


            classinfo.Source = SourceBefor + Utilities.AddSpace() + _surce;
            return classinfo;
        }

    }
}
