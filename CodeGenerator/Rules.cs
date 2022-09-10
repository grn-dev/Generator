namespace CodeGenerator
{
    public static class Rules
    {
        public static string CreatRulePath = @".Domain\Models\";
        public static string CreatinterfaceRulePath = @".Domain\Models\";
        public static string CreateErrorCodeRulePath = @".Domain\Models\";
        public static string CreateImpimentRulePath = @".Application\DomainService\";
        public static ClassInfo CreateRule(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Core.SeedWork;

namespace {input.SolutionName}.Domain.Models.Rules
{{
    public class {input.RuleName}Rule : IBusinessRule
    {{
        private readonly I{input.EntityName}RuleChecker _{input.EntityName}RuleChecker;

        private readonly int _{input.EntityName.InstanceName()}Id;
        private readonly string _{input.EntityName.InstanceName()}Name;
        

        public {input.RuleName}Rule(
            I{input.EntityName}RuleChecker {input.EntityName.InstanceName()}RuleChecker)
        {{
            _{input.EntityName}RuleChecker = {input.EntityName.InstanceName()}RuleChecker;
        }}
        //I{input.EntityName}RuleChecker {input.EntityName.InstanceName()}RuleChecker
        //CheckRule(new {input.RuleName}Rule({input.EntityName.InstanceName()}RuleChecker, driverId));
        public bool IsBroken() => _{input.EntityName}RuleChecker.{input.RuleName}(_waterEssentialPipeLineId,_{input.EntityName.InstanceName()}).Result;

        public string Message => {input.RuleName}ErrorCode.EXIST_{input.EntityName.ToUpper()}.Desc;

        public string ErrorCode => {input.RuleName}ErrorCode.EXIST_{input.EntityName.ToUpper()}.Name.ToString();
    }}
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = $"{input.RuleName}Rule.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + CreatRulePath + input.AggregateName + "\\Rules",
            };
        }
        public static ClassInfo CreateinterfaceRule(InfoRegisterClassInput input)
        {

            string _surce = $@"using System.Threading.Tasks;

namespace {input.SolutionName}.Domain.Models
{{
    public interface I{input.EntityName}RuleChecker
    {{
        Task<bool> {input.RuleName}(int waterEssentialPipeLineId, int reservoirId);
    }}
}}
";
            return new ClassInfo()
            {
                Source = _surce,
                ClassName = $"I{input.EntityName}RuleChecker.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + CreatinterfaceRulePath + input.AggregateName + "\\Rules",
            };
        }
        public static ClassInfo CreateErrorCodeRule(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Core.SeedWork;

namespace {input.SolutionName}.Domain.Models
{{
    public class {input.RuleName}ErrorCode : Enumeration
    {{
        public static {input.RuleName}ErrorCode EXIST_NAME_{input.EntityName.ToUpper()} = 
            new {input.RuleName}ErrorCode(1, nameof(EXIST_NAME_{input.EntityName.ToUpper()}), ""قبلا با این نام ثبت شده است"");


        public {input.RuleName}ErrorCode(int id, string name, string desc)
            : base(id, name, desc)
        {{

        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = $"{input.RuleName}ErrorCode.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + CreatinterfaceRulePath + input.AggregateName + "\\Rules",

            };
        }
        public static ClassInfo CreateImpimentRule(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Models;
using {input.SolutionName}.Domain.Core.SeedWork;

namespace {input.SolutionName}.Application.DomainService
{{
    [Bean]
    public class {input.EntityName}RuleChecker : I{input.EntityName}RuleChecker
    {{
        private readonly IMyMediatorHandler _mediator;
        public {input.EntityName}RuleChecker(IMyMediatorHandler mediator)
        {{
            _mediator = mediator;
        }}

            //return await _mediator.SendQuery(new AnyPredicateQuery<{input.EntityName}, int>()
            //{{
            //    Predicate = c => c.ReservoirId == reservoirId && c.WaterEssentialPipeLineId == waterEssentialPipeLineId
            //}});
    }}
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = $"{ input.EntityName }RuleChecker.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + CreateImpimentRulePath,

            };
        }
    }
}