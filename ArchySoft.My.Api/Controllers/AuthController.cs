using ArchySoft.My.Logic.Abstract.Services;
using ArchySoft.My.Logic.Models.Requests;
using ArchySoft.My.Logic.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchySoft.My.Api.Controllers
{
	public class AuthController : ControllerBase
    {
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("auth/login")]
		public AccessTokenModel Login([FromBody]LoginModel model)
		{
			AccessTokenModel result = _authService.Login(model);
			return result;
		}
	}
}