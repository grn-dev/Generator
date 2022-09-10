namespace CodeGenerator
{
    public static class ViewModel
    {
        public static string pathViewModel = @".Application\ViewModels\";

        public static ClassInfo Creat_ViewModel_Expose(InfoRegisterClassInput input)
        {


            string _surce = $@"namespace {input.SolutionName}.Application.ViewModels
{{
    public partial class {input.EntityName}ViewModel
    {{
        public class {input.EntityName}Expose
        {{
            public int Id {{ get; set; }}
            {Utilities.PropertyNONPrivet("\t\t\t\t")}
        }}
        
        public class Register{input.EntityName}
        {{
            {Utilities.PropertyNONPrivet("\t\t\t\t")} 
        }}

        public class Update{input.EntityName} : Register{input.EntityName}
        {{
            public int Id {{ get; set; }}
        }}   
    }}  
}} 
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "ViewModel.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + pathViewModel,

            };
        }

    }
}