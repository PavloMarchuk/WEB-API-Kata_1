using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArchySoft.My.Logic.Abstract.Repositories;
using ArchySoft.My.Logic.Abstract.Services;
using ArchySoft.My.Logic.Exceptions;
using ArchySoft.My.Logic.Models.Requests;
using ArchySoft.My.Logic.Models.Responses;
using ArchySoft.My.Logic.Utilities.Settings;
using ArchySoft.Shared.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ArchySoft.My.Logic.Concrete.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;
		private readonly IConfigurationSection _authOptions;

		public AuthService(IUserRepository userRepository, IConfiguration configuration)
		{
			_userRepository = userRepository;
			_authOptions = configuration.GetSection(nameof(AuthOptions));
		}

		public AccessTokenModel Login(LoginModel model)
		{
			if (model == null)
			{
				throw new BusinessException("model is null");
			}

			User user = _userRepository.GetByPassword(model.Email, model.Password);

			if (user == null)
			{
				throw new BusinessException("Wrong login or password");
			}

			return GenerateAccessToken(model, user);
		}

		private AccessTokenModel GenerateAccessToken(LoginModel model, User user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions[nameof(AuthOptions.Key)]));
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			int expiresInHours = model.RememberMe ? int.Parse(_authOptions[nameof(AuthOptions.ExpiresInMax)]) : int.Parse(_authOptions[nameof(AuthOptions.ExpiresIn)]);
			DateTime expiresIn = DateTime.UtcNow.AddHours(expiresInHours);

			JwtSecurityToken token = new JwtSecurityToken(
				_authOptions[nameof(AuthOptions.Issuer)],
				null,
				claims,
				expires: expiresIn,
				signingCredentials: signingCredentials
				);

			return new AccessTokenModel
			{
				AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
				ExpiresIn = expiresInHours
			};

		}
	}
}
