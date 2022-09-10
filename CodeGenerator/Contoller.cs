namespace CodeGenerator
{
    public static class Contoller
    {
        public static string path__Contoller = @".Api\Controllers\";


        public static ClassInfo Creat_Contoller(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Application.Services.{input.EntityName};
using {input.SolutionName}.Application.ViewModels; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garnet.Standard.Pagination;
using Garnet.Detail.Pagination.Asp.Extensions;

namespace {input.SolutionName}.Api.Controllers
{{
    [Route(""[controller]"")]
    public class {input.EntityName.ContollerName()}Controller : ApiController
    {{
        private readonly I{input.EntityName}Service _{input.EntityName.InstanceName()}Service;

        public {input.EntityName.ContollerName()}Controller(I{input.EntityName}Service {input.EntityName.InstanceName()}Service)
        {{
            _{input.EntityName.InstanceName()}Service = {input.EntityName.InstanceName()}Service;
        }}

        [HttpGet()]
        //[Authorize(Roles = (PrivilegeConstants.{input.SolutionName}_{input.EntityName} + ""1,"" + PrivilegeConstants.AdminRolePrivilage))]
        public async Task<ActionResult<List<{input.EntityName}ViewModel.{input.EntityName}Expose>>>GetAll([FromQuery] IPagination pagination)
        {{  
            var {input.EntityName.InstanceName()} = await _{input.EntityName.InstanceName()}Service.GetAllPagination(pagination); 
            return {input.EntityName.InstanceName()}.ToPaginationWithHeaderObjectResult(); 
        }}

        [HttpGet(""{{id}}"")]
        //[Authorize(Roles = (PrivilegeConstants.{input.SolutionName}_{input.EntityName} + ""3,"" + PrivilegeConstants.AdminRolePrivilage))]
        public async Task<ActionResult<{input.EntityName}ViewModel.{input.EntityName}Expose>> GetById(int id)
        {{
            return Ok(await _{input.EntityName.InstanceName()}Service.Get(id));
        }}
        
        [HttpPost]
        //[Authorize(Roles = (PrivilegeConstants.{input.SolutionName}_{input.EntityName} + ""2,"" + PrivilegeConstants.AdminRolePrivilage))]
        public async Task<IActionResult> Post([FromBody] {input.EntityName}ViewModel.Register{input.EntityName} input)
        {{
            return CustomResponse(await _{input.EntityName.InstanceName()}Service.Register(input));
        }} 

        [HttpPut]
        //[Authorize(Roles = (PrivilegeConstants.{input.SolutionName}_{input.EntityName} + ""5,"" + PrivilegeConstants.AdminRolePrivilage))]
        public async Task<IActionResult> Update([FromBody] {input.EntityName}ViewModel.Update{input.EntityName} input)
        {{
            return CustomResponse(await _{input.EntityName.InstanceName()}Service.Update(input));
        }}

        [HttpDelete(""{{id}}"")]
        //[Authorize(Roles = (PrivilegeConstants.{input.SolutionName}_{input.EntityName} + ""4,"" + PrivilegeConstants.AdminRolePrivilage))]
        public async Task<IActionResult> Delete(int id)
        {{
            return CustomResponse(await _{input.EntityName.InstanceName()}Service.Delete(id));
        }}


    }}
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName.ContollerName() + "Controller.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path__Contoller,
                FolderName = input.EntityName

            };
        }
    }
}
