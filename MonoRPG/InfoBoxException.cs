using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoRPG
{
	[System.Serializable]
	public class InfoBoxException : System.Exception
	{
		public InfoBoxException() { }
		public InfoBoxException(string message) : base(message) { }
		public InfoBoxException(string message, System.Exception inner) : base(message, inner) { }
		protected InfoBoxException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
	
}