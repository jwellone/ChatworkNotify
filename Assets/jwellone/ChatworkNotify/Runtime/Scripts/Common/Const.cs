namespace jwellone.Chatwork
{
	public static class IconPreset
	{
		public readonly static string Group = "group";
		public readonly static string Check = "check";
		public readonly static string Document = "document";
		public readonly static string Meeting = "meeting";
		public readonly static string Event = "event";
		public readonly static string Project = "project";
		public readonly static string Business = "business";
		public readonly static string Study = "study";
		public readonly static string Security = "security";
		public readonly static string Star = "star";
		public readonly static string Idea = "idea";
		public readonly static string Heart = "heart";
		public readonly static string Magcup = "magcup";
		public readonly static string Beer = "beer";
		public readonly static string Music = "music";
		public readonly static string Sports = "sports";
		public readonly static string Travel = "travel";
	}

	public enum eActionType
	{
		leave, // 退席
		delete // 削除
	}

	public enum eTaskStatus
	{
		none,
		open,
		done
	}

	public enum eLimitType
	{
		none,
		date,
		time
	}

	public enum eNeedAcceptance
	{
		none,
		no,
		yes,
	}
}