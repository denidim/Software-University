using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
        [XmlType("Purchase")]
        public class PurchaseXmlExportModel
        {
            public string Card { get; set; }

            public string Cvc { get; set; }

            public string Date { get; set; }

            public GameXmlExportModel Game { get; set; }
        }
}
/* <Card>7991 7779 5123 9211</Card> 

        <Cvc>340</Cvc> 

        <Date>2017-08-31 17:09</Date> 

        <Game title="Counter-Strike: Global Offensive"> */