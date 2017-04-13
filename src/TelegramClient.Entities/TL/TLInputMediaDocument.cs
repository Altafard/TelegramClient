using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(444068508)]
    public class TLInputMediaDocument : TLAbsInputMedia
    {
        public override int Constructor => 444068508;

        public TLAbsInputDocument id { get; set; }
        public string caption { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            id = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
            caption = StringUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(id, bw);
            StringUtil.Serialize(caption, bw);
        }
    }
}