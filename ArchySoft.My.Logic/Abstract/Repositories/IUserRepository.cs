using ArchySoft.Shared.Data.Entities;
using System.Linq;

namespace ArchySoft.My.Logic.Abstract.Repositories
{
	public interface IUserRepository
	{
		IQueryable<User> GetAll();
		User GetByPassword(string email, string password);
	}
}
