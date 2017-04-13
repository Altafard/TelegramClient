using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(594758406)]
    public class TLEncryptedMessageService : TLAbsEncryptedMessage
    {
        public override int Constructor => 594758406;

        public long random_id { get; set; }
        public int chat_id { get; set; }
        public int date { get; set; }
        public byte[] bytes { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            random_id = br.ReadInt64();
            chat_id = br.ReadInt32();
            date = br.ReadInt32();
            bytes = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(random_id);
            bw.Write(chat_id);
            bw.Write(date);
            BytesUtil.Serialize(bytes, bw);
        }
    }
}