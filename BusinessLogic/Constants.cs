namespace Remail.BusinessLogic
{
	public static class Constants
	{
		public const string Zero = "0";
		public const string DateFormat = "dd.MM.yyyy";
		public const string ShortDateFormat = "ddMM";
		public const string DecimalFormat = "##.00";
		public const string CurrencySign = " руб";
		public const int PageSize = 25;
		public const int BlrInUsd = 10600;
		public const int RoundTo = 100;
		public const string TypographyEmailSettingKey = "TypographyEmailAddress";
		public const string NoData = "-";
		public const string NotSelected = "Не выбран";
		public const string SessionKeyUser = "User";
		public const string TimeFormat = "HH:mm";
		public const int PresetsCountInRow = 4;
		public const string TempDataUserId = "UserId";
		public const string TempDataUploadedFile = "UploadedFile";
		public const string TempDataUploadedEnvelope = "UploadedEnvelope";
		public const string TempDataOrder = "Order";
		public const string Empty = "Пусто";
        public const string HtmlNewLine = "<br/>";
        public const string OrderAddresses = "OrderAdresses";
        public const string OrderImportAddresses = "OrderImportAdresses";
	    public const string CachableInterface = "ICachable";

        public static class CacheKeys
        {
            public static string InvoiceStatuses = "InvoiceStatauses";
        }
	}
}
