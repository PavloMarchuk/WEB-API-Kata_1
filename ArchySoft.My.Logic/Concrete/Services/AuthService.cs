using ArchySoft.My.Logic.Abstract.Repositories;
using ArchySoft.My.Logic.Abstract.Services;
using ArchySoft.My.Logic.Models.Requests;
using ArchySoft.My.Logic.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchySoft.My.Logic.Concrete.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;

		public TokenModel Login(LoginModel model)
		{
			throw new NotImplementedException();
		}
	}
}
