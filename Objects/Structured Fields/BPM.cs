using System.Collections.Generic;

namespace AFPParser.StructuredFields
{
	public class BPM : StructuredField
	{
		private static string _abbr = "BPM";
		private static string _title = "Begin Page Map";
		private static string _desc = "The Begin Page Map structured field begins a Page Map resource object, also called a Page Definition or PageDef. A Page Definition is a print control resource object used to compose line data into pages for printing on page printers.";
		private static List<Offset> _oSets = new List<Offset>();

		public override string Abbreviation => _abbr;
		public override string Title => _title;
		protected override string Description => _desc;
		protected override bool IsRepeatingGroup => false;
		protected override int RepeatingGroupStart => 0;
		protected override List<Offset> Offsets => _oSets;

		public BPM(int length, string hex, byte flag, int sequence) : base (length, hex, flag, sequence) { }
	}
}