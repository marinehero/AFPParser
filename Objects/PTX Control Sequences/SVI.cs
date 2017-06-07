using System.Collections.Generic;

namespace AFPParser.PTXControlSequences
{
	public class SVI : PTXControlSequence
	{
		private static string _abbr = "SVI";
		private static string _desc = "Set Variable Space Character Increment";
        private static List<Offset> _oSets = new List<Offset>()
        {
            new Offset(0, Lookups.DataTypes.SBIN, "Increment")
        };

        public override string Abbreviation => _abbr;
		public override string Description => _desc;
		public override IReadOnlyList<Offset> Offsets => _oSets;

		public SVI(byte[] data) : base(data) { }
	}
}