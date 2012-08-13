using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using NUnit.Framework;
using WarGame.Transfer;
using System.IO;

namespace Tests.Transfer
{
	[TestFixture]
	public class CardDTOTests: TestBase
	{
		[Test]
		public void SerializeAndDeserialize_ChecksIfObjectStateIsSavedCorrectly_Saved()
		{
			CardDTO card = new CardDTO(SymbolsDTO.DIAMONDS, 12);

			XmlSerializer SerializerObj = new XmlSerializer(typeof(CardDTO));

			TextWriter WriteFileStream = new StreamWriter("_cardDTO.xml");
			SerializerObj.Serialize(WriteFileStream, card);
			WriteFileStream.Close();

			FileStream ReadFileStream = new FileStream("_cardDTO.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
			CardDTO gotCard = (CardDTO)SerializerObj.Deserialize(ReadFileStream);
			ReadFileStream.Close();

			Assert.AreEqual(card.Number, gotCard.Number);
			Assert.AreEqual(card.Symbol, gotCard.Symbol);
		}
	}
}
