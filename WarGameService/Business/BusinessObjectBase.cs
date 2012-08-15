using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WarGameService.Business
{
	public class BusinessObjectBase: IDisposable
	{
		private bool _isDisposed = false;

		public virtual bool IsDisposed
		{
			get { return _isDisposed; }
			set { _isDisposed = value; }
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
