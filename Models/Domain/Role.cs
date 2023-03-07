﻿using System;
namespace NZ_Walks.Models.Domain
{
	public class Role
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public List<RoleUser> RoleUsers { get; set; }
	}
}

