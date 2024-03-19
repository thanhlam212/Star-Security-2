using domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common.Abstractions
{
    public abstract class Entity
    {
		//private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        
        //tradition code
        //public IReadOnlyList<IDomainEvent> DomainEvents { get { return _domainEvents; } }
		//modern code
        //public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

		[Key]
        public Guid Id { get; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? DeleteDate { get; protected set; }
		public DateTime? UpdatedDate { get; protected set; }

		//constructor to create id and create date every times an entity created
		protected Entity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.UtcNow;
        }

		//Method to set update date follow UTC
		public void Update()
		{
			UpdatedDate = DateTime.UtcNow;
		}

		//Method to set delete date follow UTC
		public void MarkAsDeleted()
        {
            DeleteDate = DateTime.UtcNow;
        }

		/*// Method to add domain event to the list
		public void AddDomainEvent(IDomainEvent domainEvent)
		{
			_domainEvents.Add(domainEvent);
		}

		// Method to delete all domain event
		public void ClearDomainEvents()
		{
			_domainEvents.Clear();
		}*/
	}
}
