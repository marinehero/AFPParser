﻿using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace AFPParser.PTXControlSequences
{
    public class STO : PTXControlSequence
    {
        private static string _abbr = "STO";
        private static string _desc = "Set Text Orientation";

        public override string Abbreviation => _abbr;
        protected override string Description => _desc;
        protected override List<Offset> Offsets => null;

        public STO(byte[] data) : base(data) { }

        protected override string GetOffsetDescriptions()
        {
            StringBuilder sb = new StringBuilder();

            // I/B Axis orientation stored in four total bytes.
            // Each two byte set has 3 parts. A (9 bits), B (6 bits), and C (1 bit)
            // A = 0 -359 degrees
            // B = 0 - 59 minutes
            // C = Reserved, always 0

            // Loop through both bytes
            for (int i = 0; i <= 2; i += 2)
            {
                // Get the bit values of the two bytes
                IEnumerable<bool> formattedBA;
                if (BitConverter.IsLittleEndian)
                {
                    // To flip the bytes, take each byte separately and cast it to a reversed bool array
                    IEnumerable<bool> firstBA = new BitArray(new[] { Data[i] }).Cast<bool>().Reverse();
                    IEnumerable<bool> secondBA = new BitArray(new[] { Data[i + 1] }).Cast<bool>().Reverse();

                    // Then merge them all in the right order to a new bit array
                    formattedBA = new BitArray(firstBA.Concat(secondBA).ToArray()).Cast<bool>();
                }
                else
                    formattedBA = new BitArray(new[] { Data[i], Data[i + 1] }).Cast<bool>();

                // Prepare the degree and minute bits
                IEnumerable<bool> degreeBits = formattedBA.Take(9), minuteBits = formattedBA.Skip(9).Take(6);
                if (BitConverter.IsLittleEndian)
                {
                    degreeBits = degreeBits.Reverse();
                    minuteBits = minuteBits.Reverse();
                }

                // Parse the bits out to an int array (BitArray.CopyTo sums them up for us)
                int[] values = new int[2];
                new BitArray(degreeBits.ToArray()).CopyTo(values, 0);
                new BitArray(minuteBits.ToArray()).CopyTo(values, 1);

                // Write out our values
                if (i == 0)
                    sb.AppendLine($"I Orientation: {values[0]}:{values[1]}");
                else
                    sb.AppendLine($"B Orientation: {values[0]}:{values[1]}");
            }

            return sb.ToString();
        }
    }
}