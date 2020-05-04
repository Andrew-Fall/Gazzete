using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gazette.Sanitization
{
	public static class Sanitizer
	{
		private static Regex nameRegex = new Regex("^(?=.{3,32}$)(?![_ ])(?!.*[ _]{2})[a-zA-Z0-9_ ]+(?<![_ ])$");
		private static Regex passwordRegex = new Regex("^(?=.{8,32}$)(?![_ ])(?!.*[ _]{2})[a-zA-Z0-9_ ]+(?<![_ ])$");

		public static bool NameIsValid(string name) => nameRegex.IsMatch(name);
		public static bool PasswordIsValid(string password) => passwordRegex.IsMatch(password);
	}
}
