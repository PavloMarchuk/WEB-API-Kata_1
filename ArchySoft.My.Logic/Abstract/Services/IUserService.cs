using ArchySoft.My.Logic.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchySoft.My.Logic.Abstract.Services
{
	public interface IUserService
	{
		List<UserGridModel> GetAll();
	}
}
