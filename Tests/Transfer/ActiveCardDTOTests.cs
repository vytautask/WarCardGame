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
	public class ActiveCardDTOTests: TestBase
	{
		[Test]
		public void SerializeAndDeserialize_ChecksIfObjectStateIsSavedCorrectly_Saved()
		{
			CardDTO card1 = new CardDTO(SymbolsDTO.DIAMONDS, 12);
			CardDTO card2 = new CardDTO(SymbolsDTO.HEARTS, 10);

			ActiveCardDTO activeDTO = new ActiveCardDTO(card1, card2);

			XmlSerializer SerializerObj = new XmlSerializer(typeof(ActiveCardDTO));

			TextWriter WriteFileStream = new StreamWriter("_activeCardDTO.xml");
			SerializerObj.Serialize(WriteFileStream, activeDTO);
			WriteFileStream.Close();

			FileStream ReadFileStream = new FileStream("_activeCardDTO.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
			ActiveCardDTO gotCard = (ActiveCardDTO)SerializerObj.Deserialize(ReadFileStream);
			ReadFileStream.Close();

			Assert.AreEqual(activeDTO.ComputerCard.Number, gotCard.ComputerCard.Number);
			Assert.AreEqual(activeDTO.ComputerCard.Symbol, gotCard.ComputerCard.Symbol);
			Assert.AreEqual(activeDTO.HumanCard.Number, gotCard.HumanCard.Number);
			Assert.AreEqual(activeDTO.HumanCard.Symbol, gotCard.HumanCard.Symbol);
		}

		[Test]
		public void IsLastDraw_ChecksIfItDeterminesLastDraw_Determines()
		{
			CardDTO card1 = new CardDTO(SymbolsDTO.DIAMONDS, 9);
			CardDTO card2 = new CardDTO(SymbolsDTO.HEARTS, 2);

			ActiveCardDTO activeDTO = new ActiveCardDTO(card1, card2);

			Assert.IsFalse(activeDTO.IsLastDraw());

			activeDTO.HumanCard = null;

			Assert.IsTrue(activeDTO.IsLastDraw());

			activeDTO.HumanCard = new CardDTO(SymbolsDTO.HEARTS, 5);

			Assert.IsFalse(activeDTO.IsLastDraw());

			activeDTO.ComputerCard = null;

			Assert.IsTrue(activeDTO.IsLastDraw());

			activeDTO.ComputerCard = new CardDTO(SymbolsDTO.DIAMONDS, 10);

			Assert.IsFalse(activeDTO.IsLastDraw());

			activeDTO.HumanCard = null;
			activeDTO.ComputerCard = null;

			Assert.IsTrue(activeDTO.IsLastDraw());
		}
	}
}
