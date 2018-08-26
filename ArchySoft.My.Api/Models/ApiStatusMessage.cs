namespace ArchySoft.My.Api.Models
{
    public class ApiStatusMessage
    {
		public int Status { get; }
		public string Description { get; }

		public ApiStatusMessage(int code, string description = null)
		{
			Status = code;
			Description = description ?? "Success";
		}
	}
}
