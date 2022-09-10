namespace CodeGenerator
{
    public static class Repository
    {
        public static string AddressCreatreposity = @".Infra.Data\Domain\Repository\";
        public static string AddressCreatreposityiteface = @".Domain\Repositorys\";


        public static ClassInfo Creat_Class_generic(InfoRegisterClassInput input)
        {
            string source__ = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Models;
using {input.SolutionName}.Domain.Repositorys;
using {input.SolutionName}.Infra.Data.Context;

namespace {input.SolutionName}.Infra.Data.Domain.Repository
{{
    [Bean]
    public class {input.EntityName}Repository : Repository<{input.EntityName}, {input.SolutionName}Context>, I{input.EntityName}Repository
    {{
        public {input.EntityName}Repository({input.SolutionName}Context db) : base(db)
        {{

        }} 
    }}
}}
";

            return new ClassInfo()
            {
                ClassName = input.EntityName + @"Repository" + ".cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + AddressCreatreposity,
                Source = source__

            };


        }
        public static ClassInfo Creat_interface_generic(InfoRegisterClassInput input)
        {
            string source__ = $@"using {input.SolutionName}.Domain.Models; 

namespace {input.SolutionName}.Domain.Repositorys
{{
    public interface I{input.EntityName}Repository : IRepository<{input.EntityName}>
    {{
        
    }}
}}
";

            return new ClassInfo()
            {
                ClassName = "I" + input.EntityName + @"Repository" + ".cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + AddressCreatreposityiteface,
                Source = source__

            };


        }
    }

}





