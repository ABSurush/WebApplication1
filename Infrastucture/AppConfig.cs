namespace WebApplication1.Infrastucture
{
    public class AppConfig
    {
        public TinyMCE TinyMCE { get; set; } = new TinyMCE();
        public Web Web { get; set; } = new Web();

    }

    public class TinyMCE
    {
        public string? APIKey{get; set; }
    }

    public class Web
    {
        public string? WebName { get; set; }
        public string? WebPhone { get; set; }
        public string? WebPhoneShort { get; set; }
        public string? WebEmail { get; set; }
    }
}
