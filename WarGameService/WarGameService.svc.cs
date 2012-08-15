using System;
using System.ServiceModel;
using WarGame.Transfer;
using WarGameService.Business.Managers;
using WarGameService.Business;
using System.Collections.Generic;

namespace WarGameService
{
	//TODO: in future, all business logic should be implemented in separate commands, not there
	public class WarGameService : IWarGameService
	{
		private static UserManager _userManager = null;
		private static Deck _deck = null;

		static WarGameService()
		{
		}

		public static UserManager UserManager
		{
			get
			{
				if(_userManager == null)
					_userManager = new UserManager();

				return _userManager;
			}
			set { _userManager = value; }
		}

		public static Deck Deck
		{
			get
			{
				if(_deck == null)
					_deck = new Deck();

				return _deck;
			}
			set { _deck = value; }
		}

		public ActiveCardDTO GetActiveCard()
		{
			ActiveCardDTO activeCard = new ActiveCardDTO();

			User user = GetUserFromContext();

			if(user.DeckCards.Count == 0)
			{
				activeCard.IsHumanWinner = false;
			}
			else if(user.DeckCards.Count == 52)
			{
				activeCard.IsHumanWinner = true;
			}
			else
			{
				IList<Card> missingCards = Deck.GetMissingCards(user.DeckCards);

				Random random = new Random();

				Card computerCard = missingCards[random.Next(missingCards.Count)];
				Card humanCard = user.DeckCards[0];
				activeCard.IsHumanWinner = Deck.IsCardGreater(humanCard, computerCard);

				if (activeCard.IsHumanWinner)
				{
					user.DeckCards.Add(humanCard);
					user.DeckCards.RemoveAt(0);
					user.DeckCards.Add(computerCard);
				}
				else
				{
					user.DeckCards.RemoveAt(0);
				}
				
				UserManager.UpdateUser(user);

				activeCard.ComputerCard = CardToDTOTransformer.GetCardDTO(computerCard);
				activeCard.HumanCard = CardToDTOTransformer.GetCardDTO(humanCard);
			}

			return activeCard;
		}

		public void RegisterUser(string username, string password, string firstname, string lastname)
		{

			UserManager.AddUser(new User()
			                    	{
											DeckCards = Deck.GetRandomSetOfCards(), 
											Firstname = firstname, 
											Lastname = lastname,
											Username = username,
											Password = password,
											GamesCount = 0, 
											GamesWon = 0
										});
		}

		public byte GetCardsLeft()
		{
			return (byte)GetUserFromContext().DeckCards.Count;
		}

		private User GetUserFromContext()
		{
			string username = ServiceSecurityContext.Current.PrimaryIdentity.Name;

			if (!string.IsNullOrEmpty(username))
			{
				User user = UserManager.GetUser(username);

				if (user != null)
				{
					return user;	
				}
				else
				{
					throw new ArgumentException(string.Format("User with name '{0}' was not found", username));	
				}
			}
			else
			{
				throw new ArgumentException("Username in security context is not set");	
			}
		}
	}
}
