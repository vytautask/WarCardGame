using System;
using System.Xml.Serialization;

namespace WarGame.Transfer
{
	public abstract class TransferObjectBase : IDisposable
	{
		private bool _isDisposed = false;

		[XmlIgnore]
		public bool IsDisposed
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
