namespace Api.Base.DataTypes
{
    public class PageSettings
    {
        public int DefaultPage { get; set; } = 1;
        public int DefaultPageSize { get; set; } = 100;
        public int MaxPageSize { get; set; } = 1000;
    }
}
