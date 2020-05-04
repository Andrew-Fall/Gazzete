using System;

namespace Gazette.NetworkMessages
{
	[Serializable]
	public class JoinMessage : NetworkMessage
	{
		public string Name;
		public string Password;
	}
}
