using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
	public abstract class Entity
	{
		[Key]
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		protected Entity()
		{
			Id = Guid.NewGuid();
			CreateDate = DateTime.UtcNow;
		}
		/*
		//Method to set update date follow UTC
		public void Update()
		{
			UpdatedDate = DateTime.UtcNow;
		}*/

		//Method to set delete date follow UTC
		public void MarkAsDeleted()
		{
			DeleteDate = DateTime.UtcNow;
		}

	}
}
