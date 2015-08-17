using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DevooTesting
{
    public class CharExtensionMethods
    {
        [Test]
        public void AscValue()
        {
            'a'.ASCIIValue().AssertEqualTo(0x61);
            '1'.ASCIIValue().AssertEqualTo(0x31);
            '²'.ASCIIValue().AssertEqualTo(0xb2);
        }

        [Test]
        public void EqualsIgnoreCase()
        {
            'A'.EqualsIgnoreCase('a');
            'á'.EqualsIgnoreCase('Á');
            'Á'.EqualsIgnoreCase('á');
            'Ñ'.EqualsIgnoreCase('ñ');
            'ñ'.EqualsIgnoreCase('Ñ');
        }

    }
}
