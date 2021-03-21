using ProtoBuf;
using System;

namespace Gazette.NetworkMessages
{
	[ProtoContract]
	public class UsersMessage : NetworkMessage, IClientMessage
	{
		[ProtoMember(1)]
		public string[] Users;
	}
}
