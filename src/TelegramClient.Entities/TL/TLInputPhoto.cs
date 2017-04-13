using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(-74070332)]
    public class TLInputPhoto : TLAbsInputPhoto
    {
        public override int Constructor => -74070332;

        public long id { get; set; }
        public long access_hash { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            id = br.ReadInt64();
            access_hash = br.ReadInt64();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(id);
            bw.Write(access_hash);
        }
    }
}