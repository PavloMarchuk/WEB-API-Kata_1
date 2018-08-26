using ArchySoft.My.Logic.Abstract.Repositories;
using ArchySoft.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchySoft.My.Logic.Concrete.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<User> _userMAnager;
	}
}
