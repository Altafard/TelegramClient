using System.IO;

namespace TelegramClient.Entities.TL.Help
{
    [TLObject(-1987579119)]
    public class TLAppUpdate : TLAbsAppUpdate
    {
        public override int Constructor => -1987579119;

        public int id { get; set; }
        public bool critical { get; set; }
        public string url { get; set; }
        public string text { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            id = br.ReadInt32();
            critical = BoolUtil.Deserialize(br);
            url = StringUtil.Deserialize(br);
            text = StringUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(id);
            BoolUtil.Serialize(critical, bw);
            StringUtil.Serialize(url, bw);
            StringUtil.Serialize(text, bw);
        }
    }
}