﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazette.NetworkMessages
{
	[Serializable]
	public class UsersMessage : NetworkMessage
	{
		public string[] Users;
	}
}
