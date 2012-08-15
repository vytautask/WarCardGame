using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace WarGameService.Business.Managers
{
	public abstract class ManagerBase : IDisposable
	{
		private bool _isDisposed = false;
		private static ISessionFactory _sessionFactory = null;

		public bool IsDisposed
		{
			get { return _isDisposed; }
			set { _isDisposed = value; }
		}

		private ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
					_sessionFactory = Create();

				return _sessionFactory;
			}
			set { _sessionFactory = value; }
		}

		public ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}

		private static ISessionFactory Create()
		{
			return Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2005
				          	.ConnectionString(c => c.FromAppSetting("connectionString"))
				          	.ShowSql())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<WarGameService>())
				.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
				.BuildSessionFactory();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (!IsDisposed)
			{
				if (disposing)
				{
					IsDisposed = true;
				}
			}
		}
	}
}