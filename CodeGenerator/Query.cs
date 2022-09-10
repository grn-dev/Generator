namespace CodeGenerator
{
    public static class Query
    {
        public static string path_Query = $@".Application\{AppSetting.QueryPathName}\";
        public static string path_GetByIdHandler = @".Infra.Data\Application\QueryHandler\";
        public static ClassInfo Creat_GetById(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Application.Configuration.Data.BasicQuery;
using static {input.SolutionName}.Application.ViewModels.{input.EntityName}ViewModel;
using {input.SolutionName}.Application.ViewModels;

namespace {input.SolutionName}.Application.{AppSetting.QueryPathName}.{input.EntityName}
{{ 
    public class {input.EntityName}GetByIdQuery :  
         GetByIdToDestQuery<Domain.Models.{input.EntityName}, int, {input.EntityName}AdditionalDataExpose>
    {{

    }}
     
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "GetByIdQuery.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Query + "\\" + input.EntityName + "\\",
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_GetAll(InfoRegisterClassInput input)
        {
            string _surce = $@"using {input.SolutionName}.Application.Configuration.Data.BasicQuery;
using static {input.SolutionName}.Application.ViewModels.{input.EntityName}ViewModel;
using {input.SolutionName}.Application.ViewModels;

namespace {input.SolutionName}.Application.{AppSetting.QueryPathName}.{input.EntityName}
{{ 
    public class {input.EntityName}GetAllQuery : 
        PagableQuery<Domain.Models.{input.EntityName}, int , {input.EntityName}Expose>
    {{
    }}
}}

";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "GetAllQuery.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Query + "\\" + input.EntityName + "\\",
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_GetByIdHandler(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Application.{AppSetting.QueryPathName}.{input.EntityName};
using {input.SolutionName}.Infra.Data.Application.QueryHandler.BasicQuery;
using {input.SolutionName}.Infra.Data.Context;
using {input.SolutionName}.Domain.Attributes;
using static {input.SolutionName}.Application.ViewModels.{input.EntityName}ViewModel;

namespace {input.SolutionName}.Infra.Data.Application.QueryHandler.{input.EntityName}
{{
    [Bean]
    public class {input.EntityName}GetByIdQueryHandler :  
         GetByIdToDestQueryHandler<{input.EntityName}GetByIdQuery, {input.SolutionName}.Domain.Models.{input.EntityName}, int, {input.EntityName}AdditionalDataExpose>
    {{
        public {input.EntityName}GetByIdQueryHandler({input.SolutionName}Context context) : base(context)
        {{
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "GetByIdQueryHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_GetByIdHandler + "\\" + input.EntityName + "\\",
                FolderName = input.EntityName
            };
        }
        public static ClassInfo Creat_GetAllHandler(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Application.{AppSetting.QueryPathName}.{input.EntityName};
using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Infra.Data.Application.QueryHandler.BasicQuery;
using {input.SolutionName}.Infra.Data.Context;
using static {input.SolutionName}.Application.ViewModels.{input.EntityName}ViewModel;
using {input.SolutionName}.Application.ViewModels;

namespace {input.SolutionName}.Infra.Data.Application.QueryHandler.{input.EntityName}
{{
    [Bean]
    public class {input.EntityName}GetAllQueryHandler : 
        GetAllQueryHandler<{input.EntityName}GetAllQuery, {input.SolutionName}.Domain.Models.{input.EntityName}, int, {input.EntityName}Expose>
    {{
        public {input.EntityName}GetAllQueryHandler({input.SolutionName}Context context) : base(context)
        {{
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "GetAllQueryHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_GetByIdHandler + "\\" + input.EntityName + "\\",
                FolderName = input.EntityName
            };
        }

        public static ClassInfo GetAllByPredicateQuery(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Application.Configuration.Data.BasicQuery;
using static {input.SolutionName}.Application.ViewModels.{input.EntityName}ViewModel;
namespace {input.SolutionName}.Application.Queries.{input.EntityName}
{{
    public class {input.EntityName}GetAllByPredicateQuery :
         GetAllByPredicateToDestQuery<Domain.Models.{input.EntityName}, int, {input.EntityName}Expose>
    {{ 
    }}
}}";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "GetAllByPredicateQuery.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Query + "\\" + input.AggregateName + "\\",
                FolderName = input.EntityName
            };
        }
        public static ClassInfo GetByPredicateQueryHandler(InfoRegisterClassInput input)
        {

            string _surce = $@"using {input.SolutionName}.Application.Queries.{input.EntityName};
using {input.SolutionName}.Infra.Data.Application.QueryHandler.BasicQuery;
using {input.SolutionName}.Infra.Data.Context;
using {input.SolutionName}.Domain.Attributes;
using static {input.SolutionName}.Application.ViewModels.{input.EntityName}ViewModel;

namespace {input.SolutionName}.Infra.Data.Application.QueryHandler.{input.EntityName}
{{
    [Bean]
    public class {input.EntityName}GetByPredicateQueryHandler :
        GetAllByPredicateToDestQueryHandler<{input.EntityName}GetAllByPredicateQuery, {input.SolutionName}.Domain.Models.{input.EntityName}, int,{input.EntityName}Expose>
    {{
        public {input.EntityName}GetByPredicateQueryHandler({input.SolutionName}Context context) : base(context)
        {{
        }}
    }}
}}
";


            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "GetByPredicateQueryHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_GetByIdHandler + "\\" + input.AggregateName + "\\",
                FolderName = input.EntityName
            };
        }

        public static ClassInfo CustomeQuery(InfoRegisterClassInput input, string NameQuery)
        {
            string _surce = $@"using Host.Application.Configuration.Data;
namespace {input.SolutionName}.Application.Queries.{input.EntityName}
{{
    public class {NameQuery}Query : IQuery<int>
    {{
        public int ProfileId {{ get; set; }}
    }}
}}";
            return new ClassInfo()
            {
                Source = _surce,
                ClassName = NameQuery + "Query.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_Query + "\\" + input.AggregateName + "\\",
                FolderName = input.EntityName
            };
        } 

        public static ClassInfo CustomeQueryQueryHandler(InfoRegisterClassInput input, string NameQuery)
        {
            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Application.Configuration.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using {input.SolutionName}.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using {input.SolutionName}.Application.Queries.{input.EntityName};

namespace Host.Infra.Data.Application.QueryHandler.{input.EntityName}
{{
    [Bean]
    public class {NameQuery}QueryHandler :
        IQueryHandler<{NameQuery}Query, int>
    {{
        private readonly {input.SolutionName}Context DBContext;
        public {NameQuery}QueryHandler({input.SolutionName}Context context)
        {{
            DBContext = context;
        }}
        public async Task<int> Handle(CheckHasCustomerByProfileIdQuery request, CancellationToken cancellationToken)
        {{
            var query = 1;

            return await query;
        }}
    }}
}}";
            return new ClassInfo()
            {
                Source = _surce,
                ClassName = NameQuery + "QueryHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + path_GetByIdHandler + "\\" + input.AggregateName + "\\",
                FolderName = input.EntityName
            };
        }
    }
}

