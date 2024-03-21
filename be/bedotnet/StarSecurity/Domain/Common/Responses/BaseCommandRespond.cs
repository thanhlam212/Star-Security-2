using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common.Responses
{
	public class BaseCommandRespond(
		bool success, 
		string message, 
		List<string>? errors)
	{
		public bool Success { get; set; } = success;
		public string Message { get; set; } = message;
		public List<string>? Errors { get; set; } = errors;

	}
}
