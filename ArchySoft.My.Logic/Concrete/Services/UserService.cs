using ArchySoft.My.Logic.Abstract.Repositories;
using ArchySoft.My.Logic.Abstract.Services;
using ArchySoft.My.Logic.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchySoft.My.Logic.Concrete.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public List<UserGridModel> GetAll()
		{
			List<UserGridModel> model = _userRepository.GetAll()
				.Select(u=> new UserGridModel { Id = u.Id, Email = u.Email})
				.ToList();
			return model;
		}
	}
}
