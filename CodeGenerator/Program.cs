using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodeGenerator
{
    class Program
    {
        public static int counter { get; set; }
        static void Main(string[] args)
        {

            //test asd = new asd();

            //asd.myact();
            //asd.myact1();

            ////ThreadPool.QueueUserWorkItem(() =>
            ////{
            ////    Thread.Sleep(1000);
            ////    Console.WriteLine("Work Finished");
            ////});

            //Console.WriteLine("Item Queued");

            counter = 1;
            //Befortest();
            //0PropertyesClass.txt 

            //throw new Exception("stop");

            var Project = SolutionInfoConstance.Acquirer;
            InfoRegisterClassInput input = new InfoRegisterClassInput()
            {
                EntityName = "TerminalViewModel",
                AggregateName = "VersionAPI",
                PathSolotion = Project.PathSolotion,
                SolutionName = Project.SolutionName,
            };
            input.RuleName = input.EntityName + "InviteMustbeInRequestStatus";

            input.EntityName = input.EntityName.Replace("ViewModel", "");
            creatFile(Validation.Creat_Validation_ViewModel(input));

            throw new Exception("stop");

           //DateTime.Now > 16:00
            //creatFileWithFolder(Command.Creat_register_Command(input));
            //creatFileWithFolder(Command.Creat_register_CommandhandlerV2(input));

            //creatFileWithOutBeforSource(MethodClass.Creat_MethodClass(input));
            //creatFile(ViewModel.Creat_ViewModel_Expose(input));



            //creatFileWithFolder(Events.Create_Events(input));
            //creatFile(Events.Create_EventsHandler(input));

            //creatFileWithFolder(Events.Create_Events(input, "ChangedStatus"));
            //creatFile(Events.Create_EventsHandler(input, "ChangedStatus"));

            //creatFileWithFolder(Command.Creat_register_Command(input));
            //creatFileWithFolder(Command.Creat_register_CommandhandlerV2(input));

            //creatFile(Events.Create_EventsHandler(input));
            //creatFileWithFolder(Events.Create_Events(input));

            //AddRule(input);


            //creatFileWithFolder(Events.Create_Events(input, "ChangedStatus"));
            //creatFile(Events.Create_EventsHandler(input, "ChangedStatus"));





            creatFileWithOutBeforSource(MethodClass.Creat_MethodClass(input));
            creatFile(ViewModel.Creat_ViewModel_Expose(input));


            creatFile(Service.Creat_Config(input));

            creatFile(Contoller.Creat_Contoller(input));


            creatFile(AutoMapper.Creat_AutoMapper(input));

            //creatFile(AutoMapper.Creat_AutoMapper_ForGeneric(input));
            creatFile(ViewModel.Creat_ViewModel_Expose(input));

            //AddRule(input);
            creatFileWithFolder(Service.Creat_Inteface_service(input));
            creatFileWithFolder(Service.Creat_Impliment_service(input));

            //creatFile(Service.Creat_Impliment_service_ForGeneric(input));



            //CustomQuery(input, "GetDocumentCategoryByStepModelDetailId");

            //creatFile(Service.Creat_Impliment_service(input));

            //creatFile(Contoller.Creat_Contoller(input));



            creatFileWithFolder(Command.Creat_Delete_Command(input));
            creatFileWithFolder(Command.Creat_Delete_CommandhandlerV2(input));
            creatFileWithFolder(Command.Creat_register_Command(input));
            creatFileWithFolder(Command.Creat_register_CommandhandlerV2(input));

            creatFileWithFolder(Command.Creat_Update_Command(input));
            creatFileWithFolder(Command.Creat_Update_CommandhandlerV2(input));

            //creatFileWithFolder(Command.Creat_Delete_Command(input));
            //creatFileWithFolder(Command.Creat_Delete_CommandhandlerV2(input));





            //CustomQuery(input, "GetDocumentCategoryByStepModelDetailId");
            //creatFileWithFolder(Service.Creat_Inteface_service(input));


            //creatFile(Repository.Creat_Class_generic(input));
            //creatFile(Repository.Creat_interface_generic(input));



            //creatFile(Query.CustomeQuery(input, "asd"));
            //creatFile(Query.CustomeQueryQueryHandler(input, "asd"));
            //creatFileWithOutBeforSource(MethodClass.Creat_MethodClass(input));

            //throw new Exception("----------------");
            //creatFileWithFolder(Events.Create_Events(input));
            //creatFile(Events.Create_EventsHandler(input));
            //creatFileWithFolder(Events.Create_Events(input, "ChangedStatus"));
            //creatFile(Events.Create_EventsHandler(input, "ChangedStatus"));




            //creatFileWithFolder(Service.Creat_Inteface_service(input));
            //creatFile(Service.Creat_Impliment_service(input));

            //creatFile(Contoller.Creat_Contoller(input));

            //creatFileWithOutBeforSource(MethodClass.Creat_MethodClass(input));


            //creatFile(Repository.Creat_Class_generic(input));
            //creatFile(Repository.Creat_interface_generic(input));

            //creatFileWithFolder(Command.Creat_Delete_Command(input));
            //creatFileWithFolder(Command.Creat_Delete_Commandhandler(input));

            //creatFileWithFolder(Command.Creat_Delete_Batch_Commandhandler(input));
            //creatFileWithFolder(Command.Creat_Delete_Batch_Command(input));
            //creatFileWithFolder(Command.Creat_Register_Batch_Command(input));
            //creatFileWithFolder(Command.Creat_Register_Batch_Commandhandler(input));

            //var getById = Query.Creat_GetById(input);
            //var getByIdHandler = Query.Creat_GetByIdHandler(input);
            //creatFile(Query.Creat_GetAll(input));
            //creatFile(Query.Creat_GetAllHandler(input));

            //var getByPredicateQueryHandler = Query.GetByPredicateQueryHandler(input);
            //var getAllByPredicateQuery = Query.GetAllByPredicateQuery(input);

            //var getByPredicateQueryHandler = Query.GetByPredicateQueryHandler(input);
            //var getAllByPredicateQuery = Query.GetAllByPredicateQuery(input);

            //creatFileWithFolder(Validation.Creat_Delete_Validation(input));  
            //creatFileWithFolder(Validation.Creat_Update_Validation(input));
            //creatFileWithFolder(Validation.Creat_Register_Validation(input));
            //creatFileWithFolder(Events.Create_Events(input));
            //creatFile(Events.Create_EventsHandler(input));
            //creatFileWithFolder(Events.Create_Events(input, "Changed"));
            //creatFile(Events.Create_EventsHandler(input, "Changed")); 
        }

        private static void CustomQuery(InfoRegisterClassInput input, string qname)
        {
            creatFile(Query.CustomeQuery(input, qname));
            creatFile(Query.CustomeQueryQueryHandler(input, qname));
        }
        private static void CustomCommand(InfoRegisterClassInput input, string qname)
        {
            creatFile(Query.CustomeQuery(input, qname));
            creatFile(Query.CustomeQueryQueryHandler(input, qname));
        }

        private static void AddRule(InfoRegisterClassInput input)
        {
            creatFileWithFolder(Rules.CreateRule(input));
            creatFileWithFolder(Rules.CreateinterfaceRule(input));
            creatFileWithFolder(Rules.CreateErrorCodeRule(input));
            creatFileWithFolder(Rules.CreateImpimentRule(input));
        }

        public static void creatFileWithOutBeforSource(ClassInfo classinfo)
        {

            string fileName1 = classinfo.Path + classinfo.ClassName;

            fileName1 = Utilities.FixBackSlash(fileName1);

            FileStream stream = null;
            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }
            stream = new FileStream(fileName1, FileMode.OpenOrCreate);

            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.WriteLine(classinfo.Source);
            }
            Console.WriteLine(counter + "  => " + classinfo.ClassName);
            counter++;
        }
        public static void creatFile(ClassInfo classinfo)
        {
            string fuckingFileName = classinfo.Path + classinfo.ClassName;

            fuckingFileName = Utilities.FixBackSlash(fuckingFileName);

            string fileName1 = fuckingFileName;
            FileStream stream = null;
            string SourceCodeBefor = "";
            // Create a FileStream with mode CreateNew  
            if (File.Exists(fileName1))
            {
                SourceCodeBefor = Utilities.ReadDocument(fileName1);
                File.Delete(fileName1);
                classinfo.Source = SourceCodeBefor + Utilities.AddSpace() + classinfo.Source;
            }
            stream = new FileStream(fileName1, FileMode.OpenOrCreate);


            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.WriteLine(classinfo.Source);

            }
            Console.WriteLine(counter + "  => " + classinfo.ClassName);
            counter++;
        }
        public static void creatFileWithFolder(ClassInfo classinfo)
        {
            if (!Directory.Exists(classinfo.Path))
            {
                //Directory.Delete(folderName); 
                DirectoryInfo di = Directory.CreateDirectory(classinfo.Path);
            }


            classinfo.Path = Utilities.FixBackSlash(classinfo.Path);

            string fileName1 = classinfo.Path + "\\" + classinfo.ClassName;

            fileName1 = Utilities.FixBackSlash(fileName1);


            FileStream stream = null;
            // Create a FileStream with mode CreateNew
            // 
            string SourceCodeBefor = "";
            if (File.Exists(fileName1))
            {
                SourceCodeBefor = Utilities.ReadDocument(fileName1);
                File.Delete(fileName1);
                classinfo.Source = SourceCodeBefor + Utilities.AddSpace() + classinfo.Source;
            }
            stream = new FileStream(fileName1, FileMode.OpenOrCreate);


            // Create a StreamWriter from FileStream  
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.WriteLine(classinfo.Source);

            }
            Console.WriteLine(counter + "  => " + classinfo.ClassName);
            counter++;
        }

    }
}
