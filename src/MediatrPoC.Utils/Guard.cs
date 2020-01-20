using System;

namespace MediatrPoC.Utils
{
	public static class Guard
	{
		public static void Null(object param, string paramName)
		{
			if (param == null)
			{
				throw new ArgumentNullException(paramName);
			}
		}
	}
}
