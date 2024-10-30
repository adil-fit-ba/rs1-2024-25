namespace FIT_Api_Example.Helper;

public class Config
{
    public static string AplikacijURL = "https://restapiexample.wrd.app.fit.ba/";

    public static string Slike => "profile_images/";
    public static string SlikeURL => AplikacijURL + Slike;
    public static string SlikeFolder => "wwwroot/" + Slike;
}