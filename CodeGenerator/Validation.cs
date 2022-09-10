namespace CodeGenerator
{
    public static class Validation
    {
        public static string path_impliment_Service = @".Domain\Commands\";//\DeleteTerminalRequestValidation.cs";
        public static string path_impliment_Service2 = @".Application\Validation\";//\DeleteTerminalRequestValidation.cs"; 


        public static ClassInfo Creat_Delete_Validation(InfoRegisterClassInput input)
        {
            string _surce = $@"
using FluentValidation;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}.Validations
{{
    public class Delete{input.EntityName}Validation : AbstractValidator<Delete{input.EntityName}Command>
    {{
        public Delete{input.EntityName}Validation()
        {{
            //CheckNull();
        }}
        //protected void CheckNull()
        //{{
        //    RuleFor(c => c.ProductOwnerRequestId).
        //        Null().
        //        WithMessage(""); 
        //}}
    }}
}} 
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Delete" + input.EntityName + "Validation.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_impliment_Service + "\\" + input.EntityName + "\\Validations\\",
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_Update_Validation(InfoRegisterClassInput input)
        {
            string _surce = $@"
using FluentValidation;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}.Validations
{{
    public class Update{input.EntityName}Validation : AbstractValidator<Update{input.EntityName}Command>
    {{
        public Update{input.EntityName}Validation()
        {{
            //CheckNull();
        }}
        //protected void CheckNull()
        //{{
        //    RuleFor(c => c.ProductOwnerRequestId).
        //        Null().
        //        WithMessage(""); 
        //}}
    }}
}} 
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Update" + input.EntityName + "Validation.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_impliment_Service + "\\" + input.EntityName + "\\Validations\\",
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_Register_Validation(InfoRegisterClassInput input)
        {
            string _surce = $@"using FluentValidation;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}.Validations
{{
    public class Register{input.EntityName}Validation : AbstractValidator<Register{input.EntityName}Command>
    {{
        public Register{input.EntityName}Validation()
        {{
            //CheckNull();
        }}
        //protected void CheckNull()
        //{{
        //    RuleFor(c => c.ProductOwnerRequestId).
        //        Null().
        //        WithMessage(""); 
        //}}
    }}
}} 
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Register" + input.EntityName + "Validation.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_impliment_Service + "\\" + input.EntityName + "\\Validations\\",
                FolderName = input.EntityName
            };
        }


        public static ClassInfo Creat_Validation_ViewModel(InfoRegisterClassInput input)
        {
            string _surce = $@"using FluentValidation;
using {input.SolutionName}.Application.ViewModels;
using {input.SolutionName}.Domain.Attributes;

namespace {input.SolutionName}.Application.Validation
{{
    public class {input.EntityName}Validation
    {{

        [Bean]
        public class {input.EntityName}RegisterValidator : AbstractValidator<{input.EntityName}ViewModel.Register>
        {{
            public {input.EntityName}RegisterValidator()
            {{
                RuleFor(x => x.Title).MaximumLength(255).NotNull();
                RuleFor(x => x.Descriptions).MaximumLength(1024);
            }}
        }}

        [Bean]
        public class {input.EntityName}UpdateValidator : AbstractValidator<{input.EntityName}ViewModel.Update>
        {{
            public {input.EntityName}UpdateValidator()
            {{ 
                RuleFor(x => x.Title).MaximumLength(255).NotNull();
                RuleFor(x => x.Descriptions).MaximumLength(1024);
            }}  
        }}
    }}
}}";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "Validation.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_impliment_Service2,
                FolderName = input.EntityName
            };
        }
    }
}
