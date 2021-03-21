
using Gazette.Extensions;
using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Gazette.NetworkMessages
{
	public abstract class NetworkMessage
	{
		public Guid MessageGuid = Guid.NewGuid();
		private static readonly RuntimeTypeModel SerializerModel;

		static NetworkMessage()
		{
			SerializerModel = RuntimeTypeModel.Create("NetworkMessage_Serializer");
			MetaType metaType = SerializerModel.Add(typeof(NetworkMessage), true);
			var guidMeta = metaType.AddField(255, nameof(MessageGuid));
			int index = 0;
			foreach (Type type in Assembly.GetAssembly(typeof(NetworkMessage)).GetTypes().Where(type => type.IsSubclassOf(typeof(NetworkMessage))))
				metaType.AddSubType(256 + index++, type);
			
		}

		public async Task Serialize(Stream stream)
		{
			await Task.Run(() => SerializerModel.SerializeWithLengthPrefix(stream, this, typeof(NetworkMessage), PrefixStyle.Base128, 255));
		}

		public static async Task<NetworkMessage> Deserialize(Stream stream, CancellationToken token)
		{
			NetworkMessage message = await Task.Run(() => SerializerModel.DeserializeWithLengthPrefix(stream, null, typeof(NetworkMessage), PrefixStyle.Base128, 255) as NetworkMessage).Cancellable(token);
			return message ?? throw new InvalidOperationException("Stream Closed");
		}
	}
}
