namespace CodeGenerator
{
    public static class Command
    {
        public static string path_Command = @".Domain\Commands\";
        public static string path_CommandHandler = @".Infra.Data\Application\CommandHandler\";
        public static ClassInfo Creat_register_Command(InfoRegisterClassInput input)
        {
            string _surce = $@"namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{ 
    public class Register{input.EntityName}Command : BaseCommand<int>
    {{
        {Utilities.PropertyNONPrivet()}  
    }}
}}

";

            //    public override bool IsValid()
            //{
            //    {
            //        ValidationResult = new Register { input.EntityName }Validation().Validate(this);
            //        return ValidationResult.IsValid;
            //    }
            //}


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Register" + input.EntityName + "Command.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName + "\\",
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_Update_Command(InfoRegisterClassInput input)
        {
            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Models;
using NetDevPack.Messaging;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
     
    public class Update{input.EntityName}Command : BaseCommand<int>
    {{ 
        {Utilities.PropertyNONPrivet()} 
    }}
}}
";

            //    public override bool IsValid()
            //{
            //    {
            //        ValidationResult = new Update { input.EntityName }Validation().Validate(this);
            //        return ValidationResult.IsValid;
            //    }
            //}


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Update" + input.EntityName + "Command.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_Delete_Batch_Commandhandler(InfoRegisterClassInput input)
        {
            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Common.RequestHandler;
using {input.SolutionName}.Domain.Repositorys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class DeleteBatch{input.EntityName}CommandHandler : MyBatchDeleteRequestHandler<
            DeleteBatch{input.EntityName}Command, Models.{input.EntityName}, int>
    {{

        public I{input.EntityName}Repository _repository {{ get; }}
        Task<List<{input.EntityName}>> GetAllByParentIdAsync(int parentId);
        return await _db.{input.EntityName}.AsQueryable().Where(x => x.TruckId == truckId).ToListAsync();
        public DeleteBatch{input.EntityName}CommandHandler(I{input.EntityName}Repository repository) : base(repository)
        {{
            _repository = repository;
        }}

        protected override async Task<IList<Models.{input.EntityName}>> InstantiateDomain(DeleteBatch{input.EntityName}Command request)
        {{
            return await _repository.GetByPrivilageId(request.Id);
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "DeleteBatch" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_Delete_Command(InfoRegisterClassInput input)
        {
            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Models;
using NetDevPack.Messaging;  

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{ 
    public class Delete{input.EntityName}Command : BaseCommand<int>
    {{   
    }}
}}
";
            //public override bool IsValid()
            //{{
            //    ValidationResult = new Delete{input.EntityName}Validation().Validate(this);
            //    return ValidationResult.IsValid;
            //}}

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Delete" + input.EntityName + "Command.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_register_Commandhandler(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Common.RequestHandler;
using {input.SolutionName}.Domain.Commands.{input.EntityName};
using {input.SolutionName}.Domain.Repositorys;
using System.Threading.Tasks;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class Register{input.EntityName}CommandHandler : MyCreateRequestHandler<
            Register{input.EntityName}Command, Models.{input.EntityName}, int>
    {{

        public Register{input.EntityName}CommandHandler(IRepository<Models.{input.EntityName}> repository) : base(repository)
        {{
        }}


        protected override Task<Models.{input.EntityName}> InstantiateDomain(Register{input.EntityName}Command request)
        {{
            return Task.FromResult(Models.{input.EntityName}.Create(
                {Utilities.PropertyForRegisterCommandHandler().Remove(Utilities.PropertyForRegisterCommandHandler().Length - 2, 2) + "));"}
        }}
    }}
}}

";




            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Register" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_register_CommandhandlerV2(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using System.Threading.Tasks;
using {input.SolutionName}.Infra.Data.Context;
using {input.SolutionName}.Domain.Common.RequestHandler;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class Register{input.EntityName}CommandHandler : MyCreateRequestHandler<
            Register{input.EntityName}Command, Models.{input.EntityName}, int>
    {{

        public Register{input.EntityName}CommandHandler({input.SolutionName}Context context) : base(context)
        {{
        }}


        protected override Task<Models.{input.EntityName}> InstantiateDomain(Register{input.EntityName}Command request)
        {{
            return Task.FromResult(Models.{input.EntityName}.Create(
                {Utilities.PropertyForRegisterCommandHandler().
                Remove(Utilities.PropertyForRegisterCommandHandler().Length - 2, 2) + "));"}
        }}
    }}
}}

";




            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Register" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_CommandHandler + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_Delete_Commandhandler(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Commands.{input.EntityName};
using {input.SolutionName}.Domain.Common.RequestHandler;
using {input.SolutionName}.Domain.Repositorys;
using System.Threading.Tasks;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class Delete{input.EntityName}CommandHandler : MyDeleteRequestHandler<
            Delete{input.EntityName}Command, Models.{input.EntityName}, int>
    {{
      
        public Delete{input.EntityName}CommandHandler(IRepository<Models.{input.EntityName}> repository) : base(repository)
        {{
        }}

        protected override Task<Models.{input.EntityName}> InstantiateDomain(Delete{input.EntityName}Command request)
        {{
            return Task.FromResult(Models.{input.EntityName}.DeleteRegistered(request.Id)); 
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Delete" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_Delete_CommandhandlerV2(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Common.RequestHandler; 
using {input.SolutionName}.Infra.Data.Context;
using System.Threading.Tasks;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class Delete{input.EntityName}CommandHandler : MyDeleteRequestHandler<
            Delete{input.EntityName}Command, Models.{input.EntityName}, int>
    {{
      
        public Delete{input.EntityName}CommandHandler({input.SolutionName}Context context) : base(context)
        {{
        }}

        protected override Task<Models.{input.EntityName}> InstantiateDomain(Delete{input.EntityName}Command request)
        {{
            return Task.FromResult(Models.{input.EntityName}.DeleteRegistered(request.Id)); 
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Delete" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_CommandHandler + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_Update_Commandhandler(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Commands.{input.EntityName};
using {input.SolutionName}.Domain.Common.RequestHandler;
using {input.SolutionName}.Domain.Repositorys;
using System.Threading.Tasks;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class Update{input.EntityName}CommandHandler : MyUpdateRequestHandler<
            Update{input.EntityName}Command, Models.{input.EntityName}, int>
    {{
         
        public Update{input.EntityName}CommandHandler(IRepository<Models.{input.EntityName}> repository) : base(repository)
        {{ 
        }}
 

        protected override Task UpdateFields(Models.{input.EntityName} domain, Update{input.EntityName}Command request)
        {{
            domain.Update({Utilities.PropertyForRegisterCommandHandler().Remove(Utilities.PropertyForRegisterCommandHandler().Length - 2, 2) + ");"}
            return Task.FromResult(0);
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Update" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_Update_CommandhandlerV2(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Common.RequestHandler; 
using {input.SolutionName}.Infra.Data.Context;
using System.Threading.Tasks;


namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class Update{input.EntityName}CommandHandler : MyUpdateRequestHandler<
            Update{input.EntityName}Command, Models.{input.EntityName}, int>
    {{
         
        public Update{input.EntityName}CommandHandler({input.SolutionName}Context context) : base(context)
        {{ 
        }}
 

        protected override Task UpdateFields(Models.{input.EntityName} domain, Update{input.EntityName}Command request)
        {{
            domain.Update({Utilities.PropertyForRegisterCommandHandler().Remove(Utilities.PropertyForRegisterCommandHandler().Length - 2, 2) + ");"}
            return Task.FromResult(0);
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "Update" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_CommandHandler + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_Delete_Batch_Command(InfoRegisterClassInput input)
        {

            string _surce = $@"
namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    public class DeleteBatch{input.EntityName}Command : BaseBatchCommand<int>
    {{ 
    }}
}}";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "DeleteBatch" + input.EntityName + "Command.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_Register_Batch_Command(InfoRegisterClassInput input)
        {

            string _surce = $@"using System.Collections.Generic;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    public class RegisterBatch{input.EntityName}Command : BaseBatchCommand<int>
    {{
        public List<Register{input.EntityName}Command> RegisterCommands {{ get; set; }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "RegisterBatch" + input.EntityName + "Command.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName

            };
        }
        public static ClassInfo Creat_Register_Batch_Commandhandler(InfoRegisterClassInput input)
        {
            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Common.RequestHandler;
using {input.SolutionName}.Domain.Repositorys;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace {input.SolutionName}.Domain.Commands.{input.EntityName}
{{
    [Bean]
    public class RegisterBatch{input.EntityName}CommandHandler : MyCreateBatchRequestHandler<
            RegisterBatch{input.EntityName}Command, Models.{input.EntityName}, int>
    {{

        public RegisterBatch{input.EntityName}CommandHandler(IRepository<Models.{input.EntityName}> repository) : base(repository)
        {{
        }}

        protected override Task<IList<Models.{input.EntityName}>> InstantiateDomain(RegisterBatch{input.EntityName}Command request)
        {{
            IList <Models.{input.EntityName}> entities = new List<Models.{input.EntityName}>();

            foreach (var item in request.RegisterCommands)
            {{
                entities.Add(Models.{input.EntityName}.Create(
                {Utilities.PropertyForRegisterCommandHandler().Remove(Utilities.PropertyForRegisterCommandHandler().Length - 2, 2) + "));"}
            }}
            return Task.FromResult(entities);
        }}
    }}
}}";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "RegisterBatch" + input.EntityName + "CommandHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Command + "\\" + input.AggregateName,
                FolderName = input.EntityName
            };
        }
    }
}
