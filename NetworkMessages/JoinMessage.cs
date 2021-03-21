using ProtoBuf;

namespace Gazette.NetworkMessages
{
	[ProtoContract]
	public class JoinMessage : NetworkMessage, IClientMessage
	{
		[ProtoMember(1)]
		public string Name;
		[ProtoMember(2)]
		public string Password;
	}
}
