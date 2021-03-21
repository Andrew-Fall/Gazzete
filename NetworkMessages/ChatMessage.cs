﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazette.NetworkMessages
{
	[ProtoContract]
	public class ChatMessage : NetworkMessage
	{
		[ProtoMember(1)]
		public string Text;
	}
}
