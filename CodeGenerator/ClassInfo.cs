namespace CodeGenerator
{
    public class ClassInfo
    {
        public string Path { get; set; }
        public string Source { get; set; }
        public string ClassName { get; set; }
        public string FolderName { get; set; }
    }
    public class InfoRegisterClassInput
    {
        public string SolutionName { get; set; }
        public string PathSolotion { get; set; }
        public string EntityName { get; set; }
        public string AggregateName { get; set; }
        public string RuleName { get; set; }
    }
    public class SolutionInfo
    {
        public string PathSolotion { get; set; }
        public string SolutionName { get; set; }
    }


    public static class SolutionInfoConstance
    {

        public static SolutionInfo Ghadir = new SolutionInfo() { SolutionName = "Ghadir", PathSolotion = @"C:\workshop\Ghadir\src" };
        public static SolutionInfo MakaTrip = new SolutionInfo() { SolutionName = "MakaTrip", PathSolotion = @"C:\workshop\makatrip\" };
        public static SolutionInfo IdentityServer = new SolutionInfo() { SolutionName = "IdentityServer", PathSolotion = @"C:\workshop\uaa\Identity" };
        public static SolutionInfo Host = new SolutionInfo() { SolutionName = "Host", PathSolotion = @"D:\workshop\Host\" };
        public static SolutionInfo OnlineRegistration = new SolutionInfo() { SolutionName = "OnlineRegistration", PathSolotion = @"C:\workshop\OnlineRegistration\src\" };
        public static SolutionInfo Acquirer = new SolutionInfo() { SolutionName = "Acquirer", PathSolotion = @"D:\workshop\Acquirer\src\" };
        public static SolutionInfo Communicate = new SolutionInfo() { SolutionName = "MakaCommunicate", PathSolotion = @"C:\workshop\Communicate" };
        public static SolutionInfo Chat = new SolutionInfo() { SolutionName = "Chat", PathSolotion = @"C:\workshop\Chat" };
        public static SolutionInfo Chat_home = new SolutionInfo() { SolutionName = "Chat", PathSolotion = @"D:\GitProject\Chat\" };
        public static SolutionInfo MobileApp = new SolutionInfo() { SolutionName = "MobileApp", PathSolotion = @"D:\WorkShop\mobile-app\src" };


        //D:\WorkShop\mobile-app\src\MobileApp.Domain\Models\VersionAPI\VersionAPI.cs
        public static SolutionInfo Commission = new SolutionInfo() { SolutionName = "Commission", PathSolotion = @"C:\workshop\Commission\commission\src" };
    }

}