using System.Collections.Generic;

namespace AFPParser.StructuredFields
{
	public class BDM : StructuredField
	{
		private static string _abbr = "BDM";
		private static string _title = "Begin Data Map";
		private static string _desc = "The Begin Data Map structured field begins a Data Map resource object.";
		private static List<Offset> _oSets = new List<Offset>();

		public override string Abbreviation => _abbr;
		public override string Title => _title;
		protected override string Description => _desc;
		protected override bool IsRepeatingGroup => false;
		protected override int RepeatingGroupStart => 0;
		protected override List<Offset> Offsets => _oSets;

		public BDM(int length, string hex, byte flag, int sequence) : base (length, hex, flag, sequence) { }
	}
}