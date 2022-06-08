namespace Maps_Temp
{

    /// <summary>
    /// See appsettings.json
    /// </summary>
    public class MyConfigSettings
    {
        public string OneMapEmail { get; set; }
        public string OneMapPwd { get; set; }
    }

    public class OneMapToken
    {
        public string access_token { get; set; }
        public string expiry_timestamp { get; set; }
    }
}
