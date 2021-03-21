using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazette.Extensions
{
	public static class MathExtension
	{
		public static int Clamp(int value, int min, int max) => Math.Min(Math.Max(value, min), max);
		public static int Clamp(ref this int value, int min, int max) => value = Clamp(value, min, max);
	}
}
