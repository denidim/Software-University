using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class EncryptedMessageViewModel
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
//< Message >
//        <Description>!?sdnasuoht evif-ytnewt rof deksa uoy ro orez artxe na ereht sI</Description>
//      </Message>