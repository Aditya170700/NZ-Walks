using System;
namespace NZ_Walks.Models.Domain
{
	public class RoleUser
	{
		public Guid Id { get; set; }
		public Guid RoleId { get; set; }
		public Guid UserId { get; set; }

		public Role Role { get; set; }
		public User User { get; set; }
	}
}

