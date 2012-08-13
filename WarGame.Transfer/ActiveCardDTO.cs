using System.Xml.Serialization;

namespace WarGame.Transfer
{
	public class ActiveCardDTO : TransferObjectBase
	{
		private CardDTO _humanCard = null;
		private CardDTO _computerCard = null;
		private bool _isHumanWinner = false;

		public ActiveCardDTO()
		{

		}

		public ActiveCardDTO(CardDTO humanCard, CardDTO computerCard)
		{
			HumanCard = humanCard;
			ComputerCard = computerCard;
		}

		[XmlElementAttribute("human_card")]
		public CardDTO HumanCard
		{
			get { return _humanCard; }
			set { _humanCard = value; }
		}

		[XmlElementAttribute("computer_card")]
		public CardDTO ComputerCard
		{
			get { return _computerCard; }
			set { _computerCard = value; }
		}

		[XmlElementAttribute("is_human_winner")]
		public bool IsHumanWinner
		{
			get { return _isHumanWinner; }
			set { _isHumanWinner = value; }
		}

		public bool IsLastDraw()
		{
			return (HumanCard == null || ComputerCard == null) ? true : false;
		}

		public override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!IsDisposed)
				{
					if (_humanCard != null)
					{
						_humanCard.Dispose();
						_humanCard = null;
					}

					if (_computerCard != null)
					{
						_computerCard.Dispose();
						_computerCard = null;
					}
				}
			}
			base.Dispose(disposing);
		}
	}
}
