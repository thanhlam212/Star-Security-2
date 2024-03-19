using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common.Abstractions
{
	public abstract class ValueObject
	{
		public abstract IEnumerable<object> GetAutomicValues();
		public bool Equals(ValueObject? other)
		{
			return other is not null && ValuesAreEqual(other);
		}
		public override bool Equals(object? obj)
		{
			return obj is ValueObject other && ValuesAreEqual(other);
		}

		public override int GetHashCode()
		{
			return GetAutomicValues()
				.Aggregate(
				default(int),
				HashCode.Combine);
		}

		private bool ValuesAreEqual(ValueObject other)
		{
			return GetAutomicValues().SequenceEqual(other.GetAutomicValues());
		}
	}
}
