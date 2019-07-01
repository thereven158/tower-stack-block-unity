public class ServerApiUrl
{
    private static ServerApiUrl instance = null;
    public static ServerApiUrl Instance
    {
        get
        {
            if (instance == null)
                instance = new ServerApiUrl();
            return instance;
        }
    }

#if STAG_MACHINE
    public string WaskitaGameServerUrl = "https://game-waskita-assessment-stag.agate.id";
    
#else
    public string WaskitaGameServerUrl = "https://localhost:44328";
#endif

    public string Login = "/Auth/Login";
    public string Leaderboard = "api/leaderboard";
    public string Users = "api/user";
    public string SubmitRegister = "api/register";
    //public string SubmitAvatarProps = "/User/SubmitAvatarProps";
    //public string SubmitCampArea = "/User/SubmitCampArea";
    //public string SubmitChoice = "/Choice/SubmitChoice";
    //public string SubmitHammerScore = "/HammerScore/SubmitScore";
    //public string SubmitRadioScore = "/RadioScore/SubmitScore";
    //public string SubmitSlideScore = "/SlideScore/SubmitScore";
    //public string SubmitPatternScore = "/PatternScore/SubmitScore";
}