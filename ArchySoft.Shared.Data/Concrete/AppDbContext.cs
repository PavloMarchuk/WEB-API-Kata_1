using ArchySoft.Shared.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArchySoft.Shared.Data.Concrete
{
	public class AppDbContext : IdentityDbContext<User, Role, Guid>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	}
}
