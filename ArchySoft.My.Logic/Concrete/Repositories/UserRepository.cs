using ArchySoft.My.Logic.Abstract.Repositories;
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

		public IQueryable<User> GetAll()
		{
			IQueryable<User> users = _userManager.Users;
			return users;
		}
	}
}
