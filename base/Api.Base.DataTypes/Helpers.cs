namespace Api.Base.DataTypes
{
    public static class Helpers
    {
        public static int GetPageOrDefault(this PageSettings pageSettings, int? currentPage)
        {
            if (currentPage.HasValue && currentPage.Value > 0)
            {
                return currentPage.Value;
            }

            return pageSettings != null
                ? pageSettings.DefaultPage
                : 1;
        }

        public static int GetItemsOrDefault(this PageSettings pageSettings, int? howMany)
        {
            if (howMany.HasValue)
            {
                if (pageSettings != null && pageSettings.MaxPageSize > 0 && howMany.Value > pageSettings.MaxPageSize)
                {
                    return pageSettings.MaxPageSize;
                }
                if (howMany > 0)
                {
                    return howMany.Value;
                }
            }

            return pageSettings != null
                ? pageSettings.DefaultPageSize
                : 100;
        }
    }
}
