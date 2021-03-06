﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace WarGameService.Business.Managers
{
	public class UserManager : ManagerBase
	{
		public UserManager()
		{
		}

		public IList<Card> GetUserDeck(long userId)
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					User user = session.Get<User>(userId);

					if (user != null)
						return user.DeckCards;

					return null;
				}
			}
		}

		public void SetUserDeck(long userId, IList<Card> deck)
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					User user = session.Get<User>(userId);

					if (user != null)
					{
						user.DeckCards = deck;
						session.SaveOrUpdate(user);
					}
					else
					{
						throw new ArgumentException(string.Format("User with id = '{0}' was not found", userId));
					}

					transaction.Commit();
				}
			}
		}

		public void UpdateUser(User user)
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					session.Update(user);

					transaction.Commit();
				}
			}
		}

		public long AddUser(User user)
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					//there (or in some other business class) should be some checks 
					// if user with same username is already registered

					user.Password = CalculatePasswordHash(user.Password);
					session.Save(user);

					transaction.Commit();

					return user.Id;
				}
			}
		}

		public User GetUser(string username, string password)
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					User user = session.CreateCriteria<User>()
						.Add(
							Restrictions.And(
								Restrictions.Eq("Username", username),
								Restrictions.Eq("Password", CalculatePasswordHash(password))))
						.UniqueResult<User>();

					return user;
				}
			}
		}

		public User GetUser(string username)
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					User user = session.CreateCriteria<User>()
						.Add(Restrictions.Eq("Username", username))
						.UniqueResult<User>();

					return user;
				}
			}
		}

		public User GetUser(long userId)
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					User user = session.Get<User>(userId);

					return user;
				}
			}
		}

		/// <summary>
		/// Calculates password hash. 
		/// WARNING: for the time being it calculates hash without salt. 
		/// This is really bad. In real - life you should add salt to it.
		/// </summary>
		/// <param name="password">password string in UTF-8</param>
		/// <returns>password hash</returns>
		private string CalculatePasswordHash(string password)
		{
			HashAlgorithm algorithm = SHA256.Create();
			byte[] hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));

			StringBuilder sb = new StringBuilder();
			foreach (byte b in hashBytes)
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}
	}
}