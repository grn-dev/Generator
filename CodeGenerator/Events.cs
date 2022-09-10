namespace CodeGenerator
{
    public static class Events
    {
        public static string pathEvents = @".Domain\Models\";
        public static string Create_EventsHandlerpath = @".Application\Events\";
        public static ClassInfo Create_Events(InfoRegisterClassInput input, string EventName = "Registered")
        {



            string _surce = $@"using NetDevPack.Messaging;
using System;

namespace {input.SolutionName}.Domain.Models.Events
{{

    public class {input.EntityName}{EventName}Event : Event
    {{
        public {input.EntityName}{EventName}Event(Guid aggregateId)
        {{ 
            AggregateId = aggregateId; 
        }} 
        //.AddDomainEvent(new {input.EntityName}{EventName}Event(Guid.NewGuid(),() => {input.EntityName.InstanceName()}.Id));
        public int {input.EntityName}Id {{ get; set; }}
        public Func<int> IdAccessor {{ get; set; }}
        {Utilities.PropertyNONPrivet()}  
    }} 
}} 
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + EventName + "Event.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + pathEvents + input.AggregateName + "\\" + "Events",

            };
        }

        public static ClassInfo Create_EventsHandler(InfoRegisterClassInput input, string EventName = "Registered")
        {



            string _surce = $@"using {input.SolutionName}.Domain.Attributes;
using {input.SolutionName}.Domain.Core.SeedWork;
using {input.SolutionName}.Domain.Models.Events;
using MediatR;

namespace MakaTrip.Application.Events
{{
    [Bean]
    public class {input.EntityName}EventHandler :
    INotificationHandler<{input.EntityName}{EventName}Event>
    {{ 
        private readonly IMyMediatorHandler _mediator;
        public {input.EntityName}EventHandler(IMyMediatorHandler mediatorHandler)
        {{
            _mediator = mediatorHandler;
        }} 
    }}
}}
";

            return new ClassInfo()
            {
                Source = _surce,
                ClassName = input.EntityName + "EventHandler.cs",
                Path = input.PathSolotion + "\\" + input.SolutionName + Create_EventsHandlerpath + "\\" + "Event",

            };
        }


    }
}
