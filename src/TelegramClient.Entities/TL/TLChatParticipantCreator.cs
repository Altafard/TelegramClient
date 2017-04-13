using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(-636267638)]
    public class TLChatParticipantCreator : TLAbsChatParticipant
    {
        public override int Constructor => -636267638;

        public int user_id { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            user_id = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(user_id);
        }
    }
}