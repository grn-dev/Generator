using System.Collections.Generic;

namespace CodeGenerator
{
    public static class AppSetting
    {
        public static string QueryPathName = "Queries";
        public static string DefaultSpace = "\t\t\t\t\t";
        //public static string QueryPathName = "Querys";

        public static List<string> IgnorFile()
        {
            List<string> vs = new List<string>();
            vs.Add("Id");
            vs.Add("CreateDate");
            vs.Add("ModifyDate");
            vs.Add("CreatorUserId");
            return vs;
        }
        public static SolutionInfo QueryPathNameas = new SolutionInfo() { SolutionName = "", PathSolotion = "" };

    }
}
