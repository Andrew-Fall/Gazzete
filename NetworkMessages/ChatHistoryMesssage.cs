using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazette.NetworkMessages
{
	[ProtoContract]
	public class ChatHistoryMesssage : NetworkMessage, IClientMessage
	{
		[ProtoMember(1)]
		public Dictionary<int, InternalMessage> messages;
	}

	[ProtoContract]
	public class InternalMessage
	{
		[ProtoMember(1)]
		public string Name;
		[ProtoMember(2)]
		public string Message;
	}
}
