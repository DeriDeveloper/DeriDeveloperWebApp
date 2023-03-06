namespace DeriDeveloperWebApp.Services.DataBase
{
    public class Config
    {
        public static bool RestartDB { get; } = !true;
        public static bool FillDefaultDB { get; } = !true;

        public static int CountSoftsToReturn { get; } = 10;
	}
}
