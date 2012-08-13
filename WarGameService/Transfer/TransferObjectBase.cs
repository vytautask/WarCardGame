using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Tests.Transfer
{
	public class TransferObjectBase : IDisposable, IXmlSerializable
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}

		public void ReadXml(System.Xml.XmlReader reader)
		{
			throw new NotImplementedException();
		}

		public void WriteXml(System.Xml.XmlWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
