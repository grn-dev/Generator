namespace CodeGenerator
{
    public static class Service
    {
        //C:\workshop\MakaTrip\MakaTrip.Application\Services
        public static string path_impliment_Service = @".Application.Service\Services\";
        public static string path_Interface_Iservice = @".Application\Services\";
        public static string path_Config = @".Infra.Data\Configuration\";


        public static ClassInfo Creat_Inteface_service(InfoRegisterClassInput input)
        {
            string _surce = $@"using FluentValidation.Results;
using System.Threading.Tasks; 
using {input.SolutionName}.Application.ViewModels;
using Garnet.Standard.Pagination;

namespace {input.SolutionName}.Application.Services.{input.EntityName}
{{
    public interface I{input.EntityName}Service
    {{
        Task<IPagedElements<{input.EntityName}ViewModel.{input.EntityName}Expose>> GetAllPagination(IPagination pagination);
        Task<{input.EntityName}ViewModel.{input.EntityName}Expose> Get(int id);  
        Task<ValidationResult> Register({input.EntityName}ViewModel.Register{input.EntityName} {input.EntityName.InstanceName()});
        Task<ValidationResult> Update({input.EntityName}ViewModel.Update{input.EntityName} {input.EntityName.InstanceName()});  
        Task<ValidationResult> Delete(int id); 
    }}
}}


";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = "I" + input.EntityName + "Service.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Interface_Iservice + "\\",
                //Path = input.PathSolotion + "\\" + input.SolotionName + path_Interface_Iservice + "\\" + input.ClassName,
                FolderName = input.EntityName

            };
        }


        public static ClassInfo Creat_Impliment_service(InfoRegisterClassInput input)
        {



            string _surce = $@"using AutoMapper;
using FluentValidation.Results;
using {input.SolutionName}.Application.Services.{input.EntityName};
using {input.SolutionName}.Application.ViewModels;
using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Commands.{input.EntityName};
using {input.SolutionName}.Domain.Core.SeedWork; 
using System.Threading.Tasks;
using {input.SolutionName}.Application.Configuration.Data.BasicQuery;
using {input.SolutionName}.Domain.Models;
using Garnet.Standard.Pagination;

namespace {input.SolutionName}.Application.Service.Services
{{
    [Bean]
    public class {input.EntityName}Service : ApplicationService, I{input.EntityName}Service
    {{
        private readonly IMyMediatorHandler _mediator;
        private readonly IMapper _mapper;
        

        public {input.EntityName}Service(
            IMyMediatorHandler mediatorHandler,
            IMapper mapper
            ) : base(mediatorHandler)
        {{
            _mapper = mapper;
            _mediator = mediatorHandler; 
        }}

        public async Task<{input.EntityName}ViewModel.{input.EntityName}Expose> Get(int id)
        {{
            return await _mediator.SendQuery(
                 new GetPredicateToDestQuery<{input.EntityName}, int, {input.EntityName}ViewModel.{input.EntityName}Expose>()
                 {{
                     Predicate = c => c.Id == id
                 }});
        }}

        public async Task<IPagedElements<{input.EntityName}ViewModel.{input.EntityName}Expose>> GetAllPagination(IPagination pagination)
        {{
            return await _mediator.SendQuery(
                    new PagableQuery<{input.EntityName}, int, {input.EntityName}ViewModel.{input.EntityName}Expose>()
            {{
                Pagination = pagination
            }});
        }}


        public async Task<ValidationResult> Register({input.EntityName}ViewModel.Register{input.EntityName} {input.EntityName.InstanceName()})
        {{
            return await SingleCommandExecutor(RegisterCommand, {input.EntityName.InstanceName()});
        }}
        private async Task<CommandResponse<int>> RegisterCommand({input.EntityName}ViewModel.Register{input.EntityName} {input.EntityName.InstanceName()})
        {{
            var registerCommand = _mapper.Map<Register{input.EntityName}Command>({input.EntityName.InstanceName()});
            var result = await _mediator.SendCommand(registerCommand);
            return result;
        }}

        public async Task<ValidationResult> Update({input.EntityName}ViewModel.Update{input.EntityName} {input.EntityName.InstanceName()})
        {{
            return await SingleCommandExecutor(UpdateCommand, {input.EntityName.InstanceName()}); 
        }}
        private async Task<CommandResponse<int>> UpdateCommand({input.EntityName}ViewModel.Update{input.EntityName} update{input.EntityName})
        {{
            var registerCommand = _mapper.Map<Update{input.EntityName}Command>(update{input.EntityName});
            var result = await _mediator.SendCommand(registerCommand);
            return result;
        }}
  
        public async Task<ValidationResult> Delete(int id)
        {{
            return await SingleCommandExecutor(DeleteCommand, id);
        }} 
        private async Task<CommandResponse<int>> DeleteCommand(int id)
        {{
            var result = await _mediator.SendCommand(new Delete{input.EntityName}Command()
            {{
                Id = id
            }});
            return result; 
        }} 

    }}
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "Service.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_impliment_Service,
                FolderName = input.EntityName

            };
        }


        public static ClassInfo Creat_Impliment_service_ForGeneric(InfoRegisterClassInput input)
        {

            string _surce = $@"using FluentValidation.Results;
using {input.SolutionName}.Application.Services.{input.EntityName};
using {input.SolutionName}.Application.ViewModels;
using {input.SolutionName}.Domain.Attributes; 
using {input.SolutionName}.Domain.Core.SeedWork; 
using System.Threading.Tasks;
using {input.SolutionName}.Application.Configuration.Data.BasicQuery;
using {input.SolutionName}.Domain.Models;
using Garnet.Standard.Pagination;
using {input.SolutionName}.Application.Configuration.Data.BasicCommand;

namespace {input.SolutionName}.Application.Service.Services
{{
    [Bean]
    public class {input.EntityName}Service : ApplicationService, I{input.EntityName}Service
    {{
        private readonly IMyMediatorHandler _mediator; 
        

        public {input.EntityName}Service(
            IMyMediatorHandler mediatorHandler) : base(mediatorHandler)
        {{ 
            _mediator = mediatorHandler; 
        }}

        public async Task<{input.EntityName}ViewModel.{input.EntityName}Expose> Get(int id)
        {{
            return await _mediator.SendQuery(
                 new GetPredicateToDestQuery<{input.EntityName}, int, {input.EntityName}ViewModel.{input.EntityName}Expose>()
                 {{
                     Predicate = c => c.Id == id
                 }});
        }}

        public async Task<IPagedElements<{input.EntityName}ViewModel.{input.EntityName}Expose>> GetAllPagination(IPagination pagination)
        {{
            return await _mediator.SendQuery(
                    new PagableQuery<{input.EntityName}, int, {input.EntityName}ViewModel.{input.EntityName}Expose>()
            {{
                Pagination = pagination
            }});
        }}


        public async Task<ValidationResult> Register({input.EntityName}ViewModel.Register{input.EntityName} {input.EntityName.InstanceName()})
        {{  
            var register{input.EntityName} = {input.EntityName}.
                Create(
                {Utilities.PropertyForRegisterCommandHandler(input.EntityName.InstanceName()).
                Remove(Utilities.PropertyForRegisterCommandHandler(input.EntityName.InstanceName()).Length - 2, 2) + ");"}

            return await SingleCommandExecutor<object, int>(_ =>
                _mediator.SendCommand(new GenericCreateCommand<{input.EntityName}, int>
                {{
                    DomainInitiator = () => Task.FromResult(register{input.EntityName})
                }}), null);

        }} 

        public async Task<ValidationResult> Update({input.EntityName}ViewModel.Update{input.EntityName} {input.EntityName.InstanceName()})
        {{
            var update{input.EntityName} = await _mediator.SendQuery(
                        new GetPredicateQuery<{input.EntityName}, int>()
                        {{
                            Predicate = c => c.Id == {input.EntityName.InstanceName()}.Id
                        }});

            return await SingleCommandExecutor<object, int>(_ =>
                  _mediator.SendCommand(new GenericUpdateCommand<{input.EntityName}, int>
                  {{
                      DomainInitiator = () => Task.FromResult(update{input.EntityName}),
                        DomainFieldUpdater = ac => ac.Update({Utilities.PropertyForRegisterCommandHandler(input.EntityName.InstanceName()).
                        Remove(Utilities.PropertyForRegisterCommandHandler(input.EntityName.InstanceName()).Length - 2, 2) + ")"}
                  }}), null);
        }} 

  
        public async Task<ValidationResult> Delete(int id)
        {{
            var delete{input.EntityName} = {input.EntityName}.DeleteRegistered(id);

            return await SingleCommandExecutor<object, int>(_ =>
                  _mediator.SendCommand(new GenericDeleteCommand<{input.EntityName}, int>
                  {{
                      DomainInitiator = () => Task.FromResult(delete{input.EntityName})
                  }}), null);
        }}  

    }}
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "Service.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_impliment_Service,
                FolderName = input.EntityName

            };
        }



        public static ClassInfo Creat_Config(InfoRegisterClassInput input)
        {



            string _surce = $@"using {input.SolutionName}.Domain.Models;
using {input.SolutionName}.Infra.Data.Configurations.BaseModelConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace {input.SolutionName}.Infra.Data.Configuration
{{
    public class {input.EntityName}Configuration : BaseModelConfiguration<{input.EntityName}, int>
    {{
        public {input.EntityName}Configuration(EntityTypeBuilder<{input.EntityName}> builder) : base(builder)
        {{


            builder.Property(t => t.Name).HasMaxLength(255);
            builder.Property(t => t.Code).HasMaxLength(7);
            builder.Property(t => t.Description).HasMaxLength(500);

           builder
                    .ToTable(""{input.EntityName}"");


        }}

    }}
}}


";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "Configuration.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Config,
                FolderName = input.EntityName

            };
        }
    }
}
