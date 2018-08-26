using ArchySoft.Shared.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ArchySoft.Shared.Data.Concrete
{
	public static class DbInitialiser
	{
		public static void Initialize(AppDbContext context, IServiceProvider serviceProvider)
		{


			UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
			RoleManager<Role> roleMAnager = serviceProvider.GetRequiredService<RoleManager<Role>>();

			try
			{
				context.Database.Migrate();
				if (context.Users.Any())
				{
					return;
				}

				User user = new User
				{
					Id = Guid.NewGuid(),
					Email = "qa@archysoft.com",
					EmailConfirmed = true
				};

				roleMAnager.CreateAsync(new Role { Name = "admin" });
				IdentityResult result = userManager.CreateAsync(user, "Q@Pa$$word1").Result;

				if (result.Succeeded)
				{
					userManager.AddToRoleAsync(user, "admin");
				}

			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
