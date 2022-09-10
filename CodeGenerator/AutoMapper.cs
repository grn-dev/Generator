namespace CodeGenerator
{
    public static class AutoMapper
    {
        public static string path_AutoMapper = @".Application\AutoMapper\";

        public static ClassInfo Creat_AutoMapper(InfoRegisterClassInput input)
        {

            string _surce = $@"using AutoMapper; 
using {input.SolutionName}.Application.ViewModels;
using {input.SolutionName}.Domain.Commands.{input.EntityName};
using {input.SolutionName}.Domain.Models;

namespace {input.SolutionName}.Application.AutoMapper
{{
    public class {input.EntityName}Profile : Profile
    {{
        public {input.EntityName}Profile()    
        {{
            CreateMap<{input.EntityName}, {input.EntityName}ViewModel.{input.EntityName}Expose>();  
            CreateMap<{input.EntityName}ViewModel.Register{input.EntityName}, Register{input.EntityName}Command>(); 
            CreateMap<{input.EntityName}ViewModel.Update{input.EntityName}, Update{input.EntityName}Command>(); 
        }}
    }} 
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "Profile.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_AutoMapper,
                FolderName = input.EntityName

            };
        }
        
        public static ClassInfo Creat_AutoMapper_ForGeneric(InfoRegisterClassInput input)
        {

            string _surce = $@"using AutoMapper; 
using {input.SolutionName}.Application.ViewModels; 
using {input.SolutionName}.Domain.Models;

namespace {input.SolutionName}.Application.AutoMapper
{{
    public class {input.EntityName}Profile : Profile
    {{
        public {input.EntityName}Profile()    
        {{
            CreateMap<{input.EntityName}, {input.EntityName}ViewModel.{input.EntityName}Expose>();
        }}
    }} 
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "Profile.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_AutoMapper,
                FolderName = input.EntityName

            };
        }
    }
}

