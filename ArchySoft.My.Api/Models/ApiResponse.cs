using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchySoft.My.Api.Models
{
    public class ApiResponse
    {
		public int Status { get; set; }
		public string Description { get; set; }
		public long Timestamp { get; set; }

		public object Model { get; set; }

		public ApiResponse(object model)
		{
			Status = 1;
			Description = "Success";
			Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			Model = model;
		}

		public ApiResponse(ApiStatusMessage status, string description = null)
		{
			Status = status.Status;
			Description = description ?? status.Description;
			Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		}
	}
}
