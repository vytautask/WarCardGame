using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Transfer;

namespace Tests
{
	public class Program
	{
		static void Main(string[] args)
		{
			ActiveCardDTOTests tests = new ActiveCardDTOTests();
			tests.IsLastDraw_ChecksIfItDeterminesLastDraw_Determines();

		}
	}
}
