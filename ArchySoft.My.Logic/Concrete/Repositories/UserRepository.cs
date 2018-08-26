using ArchySoft.My.Logic.Abstract.Repositories;
using ArchySoft.My.Logic.Exceptions;
using ArchySoft.Shared.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace ArchySoft.My.Logic.Concrete.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<User> _userManager;
		public UserRepository(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public User GetByPassword(string email, string password)
		{
			User user = _userManager.FindByEmailAsync(email).Result;

			if (user== null || _userManager.CheckPasswordAsync(user, password).Result == false)
			{
				throw new BusinessException("Wrong login or password");
			}

			return user;
		}

		public IQueryable<User> GetAll()
		{
			IQueryable<User> users = _userManager.Users;
			return users;
		}
	}
}
