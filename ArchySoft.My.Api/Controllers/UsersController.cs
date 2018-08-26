using System.Collections.Generic;
using ArchySoft.My.Logic.Abstract.Services;
using ArchySoft.My.Logic.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchySoft.My.Api.Controllers
{

	public class UsersController : ControllerBase
	{
		private readonly IUserService _usersService;

		public UsersController(IUserService usersService)
		{
			_usersService = usersService;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("admin/users")]
		public List<UserGridModel> GetAll()
		{
			List<UserGridModel> model = _usersService.GetAll();
			return model;
		}
	}
}