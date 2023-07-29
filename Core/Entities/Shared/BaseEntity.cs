﻿namespace Core.Entities.Shared
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedTime { get; set; }
	}
}
