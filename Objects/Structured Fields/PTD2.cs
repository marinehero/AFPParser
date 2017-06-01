using System.Collections.Generic;
using System.Text;

namespace AFPParser.StructuredFields
{
	public class PTD2 : StructuredField
	{
		private static string _abbr = "PTD";
		private static string _title = "Presentation Text Descriptor (Format 2)";
		private static string _desc = "The Presentation Text Data Descriptor structured field contains the descriptor data for a presentation text data object.";
		private static List<Offset> _oSets = new List<Offset>()
        {
            new Offset(0, Lookups.DataTypes.CODE, "X Axis Base") { Mappings = Lookups.CommonMappings.AxisBase },
            new Offset(1, Lookups.DataTypes.CODE, "Y Axis Base") { Mappings = Lookups.CommonMappings.AxisBase },
            new Offset(2, Lookups.DataTypes.UBIN, "Xp Units per Base"),
            new Offset(4, Lookups.DataTypes.UBIN, "Yp Units per Base"),
            new Offset(6, Lookups.DataTypes.UBIN, "Xp Extent"),
            new Offset(9, Lookups.DataTypes.UBIN, "Yp Extent"),
            new Offset(12, Lookups.DataTypes.EMPTY, ""),
            new Offset(14, Lookups.DataTypes.EMPTY, "Initial Text Condition Chain - CUSTOM PARSED")
        };

		public override string Abbreviation => _abbr;
		public override string Title => _title;
		protected override string Description => _desc;
		protected override bool IsRepeatingGroup => false;
		protected override int RepeatingGroupStart => 0;
		protected override List<Offset> Offsets => _oSets;

		public PTD2(int length, string hex, byte flag, int sequence) : base (length, hex, flag, sequence) { }

        protected override string GetSingleOffsetDescription(Offset oSet, byte[] sectionedData)
        {
            if (oSet.StartingIndex != 14)
                return base.GetSingleOffsetDescription(oSet, sectionedData);

            StringBuilder sb = new StringBuilder();

            // This section can specify default values for control sequences. Load them up as normal sequences
            sb.AppendLine("Initial text conditions not yet implemented...");

            return sb.ToString();
        }
    }
}