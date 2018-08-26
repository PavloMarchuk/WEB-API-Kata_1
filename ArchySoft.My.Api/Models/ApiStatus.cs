namespace ArchySoft.My.Api.Models
{
	public class ApiStatus
	{
		public static ApiStatusMessage Success = new ApiStatusMessage(1);
		public static ApiStatusMessage Exception = new ApiStatusMessage(-1, "Internal server error");
	}
}
