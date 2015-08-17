using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace DevooTesting
{
    
    public class StringExtensionMethodsTest
    {
        

        [Test]
        public void Right()
        {
            "abcd".Right(0).AssertIsEmpty();
            "abcd".Right(1).AssertEqualTo("d");
            "abcde".Right(2).AssertEqualTo("de");
            "ab".Right(2).AssertEqualTo("ab");            
            "a".Right(2).AssertEqualTo("a");
            string.Empty.Right(2).AssertIsEmpty();
            ((string) null).Right(2).AssertIsEmpty();
            Assert.Throws<ArgumentException>(() => "a".Right(-1));
        }

        [Test]
        public void Left()
        {

            "abcd".Left(0).AssertIsEmpty();
            "abcd".Left(1).AssertEqualTo("a");
            "abcde".Left(2).AssertEqualTo("ab");
            "de".Left(2).AssertEqualTo("de");
            "a".Left(2).AssertEqualTo("a");
            string.Empty.Left(2).AssertIsEmpty();
            ((string)null).Left(2).AssertIsEmpty();
            Assert.Throws<ArgumentException>(() => "a".Left(-1));
        }


        [Test]
        public void ContainsOnlyThisChar()
        {
            "abcd".ContainsOnlyThisChar('a').AssertIsFalse();
            "aaaa".ContainsOnlyThisChar('a').AssertIsTrue();
            "a".ContainsOnlyThisChar('a').AssertIsTrue();
            string.Empty.ContainsOnlyThisChar('a').AssertIsFalse();
            "b".ContainsOnlyThisChar('a').AssertIsFalse();
        }


        [Test]
        public void ToCapitalCase()
        {
            "abcd".ToCapitalCase().AssertEqualTo("Abcd");
            "ab cd".ToCapitalCase().AssertEqualTo("Ab Cd");
            "Ab Cd".ToCapitalCase().AssertEqualTo("Ab Cd");
            "AB CD".ToCapitalCase().AssertEqualTo("Ab Cd");
            "A".ToCapitalCase().AssertEqualTo("A");
            "a".ToCapitalCase().AssertEqualTo("A");

            string.Empty.ToCapitalCase().AssertIsEmpty();

            "AB OF CD".ToCapitalCase().AssertEqualTo("Ab Of Cd");
            "AB The CD".ToCapitalCase().AssertEqualTo("Ab The Cd");
        }

        [Test]
        public void ToCamelCase()
        {
            "abcd".ToCamelCase().AssertEqualTo("abcd");
            "ABCD".ToCamelCase().AssertEqualTo("aBCD");
            "Ab cd".ToCamelCase().AssertEqualTo("ab cd");
            "A".ToCamelCase().AssertEqualTo("a");
            "a".ToCamelCase().AssertEqualTo("a");

            string.Empty.ToCamelCase().AssertIsEmpty();

        }

        [Test]
        public void Truncate()
        {
            "abcdef".Truncate(0).AssertIsEmpty();

            "This is a long text".Truncate(6).AssertEqualTo("Thi...");
            "This is a long text".Truncate(100).AssertEqualTo("This is a long text");
            "abcdef".Truncate(3).AssertEqualTo("ab.");
            "a".Truncate(3).AssertEqualTo("a");
            "abc".Truncate(3).AssertEqualTo("abc");
            string.Empty.Truncate(3).AssertIsEmpty();
            string.Empty.Truncate(0).AssertIsEmpty();
    
        }


        [Test]
        public void ReplaceRecursive()
        {
            "abcdef".ReplaceRecursive("  ", " ").AssertEqualTo("abcdef");

            "ab  cdef".ReplaceRecursive("  ", " ").AssertEqualTo("ab cdef");
            "ab   cdef".ReplaceRecursive("  ", " ").AssertEqualTo("ab cdef"); 
            "ab    cdef".ReplaceRecursive("  ", " ").AssertEqualTo("ab cdef");
            "ab     cdef".ReplaceRecursive("  ", " ").AssertEqualTo("ab cdef");

            "  cdef".ReplaceRecursive("  ", " ").AssertEqualTo(" cdef");
            "   cdef".ReplaceRecursive("  ", " ").AssertEqualTo(" cdef");
            "    cdef".ReplaceRecursive("  ", " ").AssertEqualTo(" cdef");
            "     cdef".ReplaceRecursive("  ", " ").AssertEqualTo(" cdef");

            "ab  ".ReplaceRecursive("  ", " ").AssertEqualTo("ab ");
            "ab   ".ReplaceRecursive("  ", " ").AssertEqualTo("ab ");
            "ab    ".ReplaceRecursive("  ", " ").AssertEqualTo("ab ");
            "ab     ".ReplaceRecursive("  ", " ").AssertEqualTo("ab ");

            " ".ReplaceRecursive("  ", " ").AssertEqualTo(" ");
            "  ".ReplaceRecursive("  ", " ").AssertEqualTo(" ");
            "   ".ReplaceRecursive("  ", " ").AssertEqualTo(" ");
            "    ".ReplaceRecursive("  ", " ").AssertEqualTo(" ");
            "     ".ReplaceRecursive("  ", " ").AssertEqualTo(" ");
            "      ".ReplaceRecursive("  ", " ").AssertEqualTo(" ");
            "       ".ReplaceRecursive("  ", " ").AssertEqualTo(" ");

        }

        [Test]
        public void AvoidNull()
        {
            "abcdef".AvoidNull().AssertEqualTo("abcdef");
            string.Empty.AvoidNull().AssertIsEmpty();
            ((string) null).AvoidNull().AssertIsEmpty();
        }

        [Test]
        public void EndsWithIgnoreCase()
        {
            "abcdef".EndsWithIgnoreCase("def").AssertIsTrue();
            "abcdef".EndsWithIgnoreCase("dEf").AssertIsTrue();
            "abcdef".EndsWithIgnoreCase("DEf").AssertIsTrue();
            "abcdef".EndsWithIgnoreCase("DEF").AssertIsTrue();


            "AbcDef".EndsWithIgnoreCase("def").AssertIsTrue(); 
            "abcdEf".EndsWithIgnoreCase("def").AssertIsTrue();
            "abcdEF".EndsWithIgnoreCase("def").AssertIsTrue();
            "abcDEF".EndsWithIgnoreCase("def").AssertIsTrue();
            "Abcdef".EndsWithIgnoreCase("def").AssertIsTrue();

            "Abcdef".EndsWithIgnoreCase(string.Empty).AssertIsTrue();
            "Abcdef".EndsWithIgnoreCase(null).AssertIsTrue();

            "abcdef".EndsWithIgnoreCase("ah").AssertIsFalse();
            string.Empty.EndsWithIgnoreCase("av").AssertIsFalse();
            
            string.Empty.EndsWithIgnoreCase(null).AssertIsTrue();
            ((string)null).EndsWithIgnoreCase(string.Empty).AssertIsTrue();
            ((string)null).EndsWithIgnoreCase(null).AssertIsTrue();

        }


        [Test]
        public void EqualsIgnoreAccent()
        {
            "".EqualsIgnoreCaseAndAccent("").AssertIsTrue();
            "abc".EqualsIgnoreCaseAndAccent("abc").AssertIsTrue();
            "aBc".EqualsIgnoreCaseAndAccent("abc").AssertIsTrue();
            "abc".EqualsIgnoreCaseAndAccent("abC").AssertIsTrue();

            "áéíóúñ".EqualsIgnoreCaseAndAccent("aeioun").AssertIsTrue();
            "ÁÉÍÓÚÑ".EqualsIgnoreCaseAndAccent("AEIOUN").AssertIsTrue();

            "ÀÁÂÃÄÅĀāĂă".EqualsIgnoreCaseAndAccent("aaaaaAAAAA").AssertIsTrue();
            "ÈÉÊË".EqualsIgnoreCaseAndAccent("eeee").AssertIsTrue();
            "ÌÍÎÏ".EqualsIgnoreCaseAndAccent("iiii").AssertIsTrue();
            "ÖÕÔÓÒ".EqualsIgnoreCaseAndAccent("ooooo").AssertIsTrue();
            "ÙÚÛÜ".EqualsIgnoreCaseAndAccent("uuuu").AssertIsTrue();

            "áéíóúñ".EqualsIgnoreCaseAndAccent("AEIOUN").AssertIsTrue();
            "ÁÉÍÓÚÑ".EqualsIgnoreCaseAndAccent("aeioun").AssertIsTrue();

            "Üü".EqualsIgnoreCaseAndAccent("UU").AssertIsTrue();
            "Üü".EqualsIgnoreCaseAndAccent("uu").AssertIsTrue();

            "abc".EqualsIgnoreCaseAndAccent("abCde").AssertIsFalse();
            "123abc".EqualsIgnoreCaseAndAccent("abc").AssertIsFalse();

            string.Empty.EqualsIgnoreCaseAndAccent(null).AssertIsFalse();
            ((string) null).EqualsIgnoreCaseAndAccent(string.Empty).AssertIsFalse();
            ((string) null).EqualsIgnoreCaseAndAccent(null).AssertIsTrue();
        }


        [Test]
        public void StartWithIgnoreCase()
        {
            "abcdef".StartsWithIgnoreCase("abc").AssertIsTrue();
            "abcdef".StartsWithIgnoreCase("aBc").AssertIsTrue();
            "abcdef".StartsWithIgnoreCase("AbC").AssertIsTrue();
            "abcdef".StartsWithIgnoreCase("ABC").AssertIsTrue();


            "AbcDef".StartsWithIgnoreCase("abc").AssertIsTrue();
            "abcdEf".StartsWithIgnoreCase("abc").AssertIsTrue();
            "abcdEF".StartsWithIgnoreCase("abc").AssertIsTrue();
            "abcDEF".StartsWithIgnoreCase("abc").AssertIsTrue();
            "Abcdef".StartsWithIgnoreCase("abc").AssertIsTrue();

            "Abcdef".StartsWithIgnoreCase(string.Empty).AssertIsTrue();
            "Abcdef".StartsWithIgnoreCase(null).AssertIsTrue();

            "abcdef".StartsWithIgnoreCase("ht").AssertIsFalse();
            string.Empty.StartsWithIgnoreCase("wr").AssertIsFalse();

            string.Empty.StartsWithIgnoreCase(null).AssertIsTrue();
            ((string)null).StartsWithIgnoreCase(string.Empty).AssertIsTrue();
            ((string)null).StartsWithIgnoreCase(null).AssertIsTrue();

        }

        [Test]
        public void IndexOfIgnoreCase()
        {
            "abcdef".IndexOfIgnoreCase("abc").AssertEqualTo(0);
            "aBcdef".IndexOfIgnoreCase("abc").AssertEqualTo(0);
            "ABCdef".IndexOfIgnoreCase("abc").AssertEqualTo(0);
            "aBcdef".IndexOfIgnoreCase("aBc").AssertEqualTo(0);
            "aBcdef".IndexOfIgnoreCase("aBC").AssertEqualTo(0);
            "gabcdef".IndexOfIgnoreCase("abc").AssertEqualTo(1);
            "saBcdef".IndexOfIgnoreCase("abc").AssertEqualTo(1);
            "nABCdef".IndexOfIgnoreCase("abc").AssertEqualTo(1);
            "3aBcdef".IndexOfIgnoreCase("aBc").AssertEqualTo(1);
            "6aBcdef".IndexOfIgnoreCase("aBC").AssertEqualTo(1);
            "abcdef".IndexOfIgnoreCase(string.Empty).AssertEqualTo(0);
            "abcdef".IndexOfIgnoreCase("asdf").AssertCondition(x => x < 0);
            Assert.Throws<ArgumentNullException>(() => "abcdef".IndexOfIgnoreCase(null));
            Assert.Throws<ArgumentNullException>(() => string.Empty.IndexOfIgnoreCase(null));
            Assert.Throws<NullReferenceException>(() => ((string)null).IndexOfIgnoreCase("asd"));
            Assert.Throws<NullReferenceException>(() => ((string)null).IndexOfIgnoreCase(string.Empty));

            //Con la posicion inicial de la busqueda startIndex
            "abcdef".IndexOfIgnoreCase(0, "abc").AssertEqualTo(0);
            "aBcdef".IndexOfIgnoreCase(0, "abc").AssertEqualTo(0);
            "ABCdef".IndexOfIgnoreCase(1, "c").AssertEqualTo(2);
            "aBcdef".IndexOfIgnoreCase(0, "aBc").AssertEqualTo(0);
            "aBcdef".IndexOfIgnoreCase(0, "aBC").AssertEqualTo(0);
            "gabcdef".IndexOfIgnoreCase(0, "abc").AssertEqualTo(1);
            "saBcdef".IndexOfIgnoreCase(0, "abc").AssertEqualTo(1);
            "nABCdef".IndexOfIgnoreCase(0, "abc").AssertEqualTo(1);
            "3aBcdef".IndexOfIgnoreCase(0, "aBc").AssertEqualTo(1);
            "6aBcdef".IndexOfIgnoreCase(0, "aBC").AssertEqualTo(1);
            "abcdef".IndexOfIgnoreCase(3, string.Empty).AssertEqualTo(3);
            "abcdef".IndexOfIgnoreCase(0, "asdf").AssertCondition(x => x < 0);
            Assert.Throws<ArgumentNullException>(() => "abcdef".IndexOfIgnoreCase(0, null));
            Assert.Throws<ArgumentNullException>(() => string.Empty.IndexOfIgnoreCase(0, null));
            Assert.Throws<NullReferenceException>(() => ((string)null).IndexOfIgnoreCase(0, "asd"));
            Assert.Throws<NullReferenceException>(() => ((string)null).IndexOfIgnoreCase(0, string.Empty));  
        }        

        [Test]
        public void IsNullOrEmpty()
        {
            ((string)null).IsNullOrEmpty().AssertIsTrue();
            string.Empty.IsNullOrEmpty().AssertIsTrue();
            "".IsNullOrEmpty().AssertIsTrue();
            " ".IsNullOrEmpty().AssertIsFalse();
            "abc".IsNullOrEmpty().AssertIsFalse();
        }

        [Test]
        public void NotIsNullOrEmpty()
        {
            ((string)null).NotIsNullOrEmpty().AssertIsFalse();
            string.Empty.NotIsNullOrEmpty().AssertIsFalse();
            "".NotIsNullOrEmpty().AssertIsFalse();
            " ".NotIsNullOrEmpty().AssertIsTrue();
            "abc".NotIsNullOrEmpty().AssertIsTrue();
        }

        [Test]
        public void JoinToString()
        {
            "abc".JoinToString().AssertEqualTo("a,b,c");
            new[] { "a", "b", "c" }.JoinToString().AssertEqualTo("a,b,c");
            new[] { 'a', 'b', 'c' }.JoinToString().AssertEqualTo("a,b,c");
            new object[] { 'a', new StringBuilder("b"), 'c' }.JoinToString().AssertEqualTo("a,b,c");

            "abc".JoinToString("").AssertEqualTo("abc");
            new[] { "a", "b", "c" }.JoinToString("").AssertEqualTo("abc");
            new[] { 'a', 'b', 'c' }.JoinToString("").AssertEqualTo("abc");
            new object[] { 'a', new StringBuilder("b"), 'c' }.JoinToString("").AssertEqualTo("abc");

            "abc".JoinToString(",").AssertEqualTo("a,b,c");
            new[] { "a", "b", "c" }.JoinToString(",").AssertEqualTo("a,b,c");
            new[] { 'a', 'b', 'c' }.JoinToString(",").AssertEqualTo("a,b,c");
            new object[] { 'a', new StringBuilder("b"), 'c' }.JoinToString(",").AssertEqualTo("a,b,c");


            "abc".JoinToString("*").AssertEqualTo("a*b*c");
            new[] { "a", "b", "c" }.JoinToString("*").AssertEqualTo("a*b*c");
            new[] { 'a', 'b', 'c' }.JoinToString("*").AssertEqualTo("a*b*c");
            new object[] { 'a', new StringBuilder("b"), 'c' }.JoinToString("*").AssertEqualTo("a*b*c");

        }


        [Test]
        public void EnumerateLines()
        {
           
           var valores = @"1	71619366
1	27076724
1	1000791136
1	79522923".EnumerateLines().ToArray();

            valores.Length.AssertEqualTo(4);
            valores[0].AssertEqualTo("1	71619366");
            valores[3].AssertEqualTo("1	79522923");

            valores = @"1	71619366
1	27076724
1	1000791136
1	79522923
".EnumerateLines().ToArray();

            valores.Length.AssertEqualTo(4);
            valores[0].AssertEqualTo("1	71619366");
            valores[3].AssertEqualTo("1	79522923");

            valores = @"".EnumerateLines().ToArray();
            valores.Length.AssertEqualTo(0);

            valores = @" ".EnumerateLines().ToArray();
            valores.Length.AssertEqualTo(1);
            valores[0].AssertEqualTo(" ");

            valores = @"
".EnumerateLines().ToArray();
            valores.Length.AssertEqualTo(1);


        }


        [Test]
        public void CountLines()
        {

            @"1	71619366
1	27076724
1	1000791136
1	79522923".CountLines().AssertEqualTo(4);

                        @"1	71619366
1	27076724
1	1000791136
1	79522923
".CountLines().AssertEqualTo(4);
            
            @"".CountLines().AssertEqualTo(0);
            
            @" ".CountLines().AssertEqualTo(1);

            @"
".CountLines().AssertEqualTo(1);


        }

        [Test]
        public void Fill()
        {
            "abc".Fill().AssertEqualTo("abc");
            "abc {0}".Fill("").AssertEqualTo("abc ");
            
            "abc {0}".Fill("def").AssertEqualTo("abc def");

            Assert.Throws<FormatException>(() => "{0 }".Fill()); 
            Assert.Throws<FormatException>(() => "{0}".Fill()); 
            Assert.Throws<FormatException>(() => "abc {0}".Fill());
            Assert.Throws<ArgumentNullException>(() => "abc {0}".Fill(null));
        }

        [Test]
        public void Remove()
        {
            "abcde".Remove("ab").AssertEqualTo("cde");
            "abcde".Remove("bc").AssertEqualTo("ade");
            "abcde".Remove("de").AssertEqualTo("abc");
        }

        [Test]
        public void Replace()
        {
            "abcde".Replace("ab", "zx", StringComparison.CurrentCulture).AssertEqualTo("zxcde");
            "abcde".Replace("de", "zx", StringComparison.CurrentCulture).AssertEqualTo("abczx");
            "abcde".Replace("cd", "zx", StringComparison.CurrentCulture).AssertEqualTo("abzxe");
            //Probar con los demas StringComparison
        }

        [Test]
        public void ReplaceIgnoringCase()
        {
            "ABcde".ReplaceIgnoringCase("ab", "zx").AssertEqualTo("zxcde");
            "abcde".ReplaceIgnoringCase("Ab", "zx").AssertEqualTo("zxcde");
        }

        [Test]
        public void IsEmpty()
        {
            "".IsEmpty().AssertIsTrue();
            "a".IsEmpty().AssertIsFalse();
            "ab".IsEmpty().AssertIsFalse();
            "abc".IsEmpty().AssertIsFalse();
        }

        [Test]
        public void Substring()
        {
            "abcde".Substring("a").AssertEqualTo("abcde");
            "abcde".Substring("cd").AssertEqualTo("cde");
            "abcde".Substring("e").AssertEqualTo("e");                        
            Assert.Throws<ArgumentException>(() => "abcde".Substring("z"));
        }

        [Test]
        public void Contains()
        {            
            "abcde".Contains(new[] {"a","b"}).AssertIsTrue();
            "abcde".Contains(new[] {""}).AssertIsTrue();
            "abcde".Contains(new[] {"z"}).AssertIsFalse();
        }

        [Test]
        public void ContainsIgnoreCase()
        {
            "abCde".ContainsIgnoreCase("bc").AssertIsTrue();
            "abCde".ContainsIgnoreCase("bC").AssertIsTrue();
            Assert.Throws<ArgumentException>(() => "abCde".ContainsIgnoreCase(""));
            Assert.Throws<ArgumentException>(() => "abCde".ContainsIgnoreCase(null));
        }

        [Test]
        public void ToValidIdentifier()
        {
            "".ToValidIdentifier().AssertEqualTo("_");
            "1abc".ToValidIdentifier().AssertEqualTo("1Abc");
            "abc".ToValidIdentifier().AssertEqualTo("Abc");
            "_abc".ToValidIdentifier().AssertEqualTo("Abc");
            "a_bc".ToValidIdentifier().AssertEqualTo("A_Bc");
            "ab@c".ToValidIdentifier().AssertEqualTo("Ab_C");
        }

        [Test]
        public void TrimAll()
        {
            IList<string> strings = new List<string>();
            IList<string> stringsResultado = new List<string>();
            
            strings.Add("   abc   ");
            stringsResultado.Add("abc");

            strings.Add("a b");
            stringsResultado.Add("a b");

            strings.Add("abc de ");
            stringsResultado.Add("abc de");

            strings.Add("a  b  c");
            stringsResultado.Add("a  b  c");

            strings.TrimAll();
            strings.AssertEqualTo(stringsResultado);
        }
        

        [Test]
        public void EqualsIgnoreCase()
        {
            "".EqualsIgnoreCase("").AssertIsTrue();
            "abc".EqualsIgnoreCase("abc").AssertIsTrue();
            "aBc".EqualsIgnoreCase("abc").AssertIsTrue();
            "abc".EqualsIgnoreCase("abC").AssertIsTrue();
            "abc".EqualsIgnoreCase("abCde").AssertIsFalse();
            "123abc".EqualsIgnoreCase("abc").AssertIsFalse();
        }

        [Test]
        public void CharEqualsIgnoreCase()
        {
            ' '.EqualsIgnoreCase(' ').AssertIsTrue();
            'a'.EqualsIgnoreCase('a').AssertIsTrue();
            'A'.EqualsIgnoreCase('a').AssertIsTrue();
            'a'.EqualsIgnoreCase('A').AssertIsTrue();
            'ñ'.EqualsIgnoreCase('Ñ').AssertIsTrue();
        }

        [Test]
        public void EqualsToAnyIgnoreCase()
        {
            "".EqualsToAnyIgnoreCase().AssertIsFalse();
            "".EqualsToAnyIgnoreCase("asd", null).AssertIsFalse();
            "".EqualsToAnyIgnoreCase("", "abc").AssertIsTrue();
            "".EqualsToAnyIgnoreCase(null, "", "abc").AssertIsTrue();
            "abc".EqualsToAnyIgnoreCase("", "abc").AssertIsTrue();
            "aBc".EqualsToAnyIgnoreCase("", "abc").AssertIsTrue();
            "abc".EqualsToAnyIgnoreCase("abC", "").AssertIsTrue();
            "abc".EqualsToAnyIgnoreCase("abCde", "").AssertIsFalse();
            "123abc".EqualsToAnyIgnoreCase("123","abc").AssertIsFalse();
        }


        [Test]
        public void TrimPhrase()
        {
            "hi".TrimPhrase(null).AssertEqualTo("hi");
            ((string)null).TrimPhrase("asdf").AssertEqualTo(string.Empty);

            "hola".TrimPhrase("ho").AssertEqualTo("la");
            "holahoho".TrimPhrase("ho").AssertEqualTo("la");

            "laho".TrimPhrase("ho").AssertEqualTo("la");
            "ho".TrimPhrase("ho").AssertEqualTo("");
            "hohohoho".TrimPhrase("ho").AssertEqualTo("");

        }

        [Test]
        public void TrimPhraseStart()
        {
            "hi".TrimPhraseStart(null).AssertEqualTo("hi");
            ((string)null).TrimPhraseStart("asdf").AssertEqualTo(string.Empty);

            "hola".TrimPhraseStart("ho").AssertEqualTo("la");
            "holahoho".TrimPhraseStart("ho").AssertEqualTo("lahoho");

            "laho".TrimPhraseStart("ho").AssertEqualTo("laho");
            "ho".TrimPhraseStart("ho").AssertEqualTo("");
            "hohohoho".TrimPhraseStart("ho").AssertEqualTo("");

        }

        [Test]
        public void TrimPhraseEnd()
        {
            "hi".TrimPhraseEnd(null).AssertEqualTo("hi");
            ((string)null).TrimPhraseEnd("asdf").AssertEqualTo(string.Empty);

            "hola".TrimPhraseEnd("ho").AssertEqualTo("hola");
            "holahoho".TrimPhraseEnd("ho").AssertEqualTo("hola");

            "laho".TrimPhraseEnd("ho").AssertEqualTo("la");
            "ho".TrimPhraseEnd("ho").AssertEqualTo("");
            "hohohoho".TrimPhraseEnd("ho").AssertEqualTo("");

        }

        [Test]
        public void ExtractAround()
        {
            ((string)null).TrimPhraseEnd("asdf").AssertEqualTo(string.Empty);
            
            "hola".ExtractAround(2, 1, 1).AssertEqualTo("ol");
            "hola".ExtractAround(2, 1, 2).AssertEqualTo("ola");
            "hola".ExtractAround(2, 100, 100).AssertEqualTo("hola");

            "hola".ExtractAround(2, 1, 0).AssertEqualTo("o");
            "hola".ExtractAround(2, 0, 1).AssertEqualTo("l");
            "hola".ExtractAround(2, 0, 0).AssertEqualTo("");

            Assert.Throws<IndexOutOfRangeException>(() =>
                    "hola".ExtractAround(100, 1, 1));

        }

        [Test]
        [TestCase("mi nombre y apellido", "minombre y apellido", false, true)]
        [TestCase("mi nombre y apellido", "mi nombre y apellido", false, false)]
        [TestCase("mi nxmbre y apellido", "mi nombre y apellido", true, false)]
        [TestCase("mi nombre y apellido", "mi nombre y apellidx", true, false)]
        [TestCase("mi nombre y xpellido", "mi nombre y apellidx", false, false)]
        [TestCase("mi nombre y xpellido", "mi nombre y apellixx", false, false)]
        [TestCase("one", "two", false, false)]
        public void DiffOnlyOneChar(string text1, string text2, bool expected,bool generaException)
        {
            if (generaException)
                Assert.Throws<ArgumentException>(() => text1.DiffOnlyOneChar(text2));
            else
                text1.DiffOnlyOneChar(text2).AssertEqualTo(expected);
        }

        [Test]
        [TestCase("mi nombre y apellido", "minombre y apellido", 0, true)]
        [TestCase("mi nombre y apellido", "mi nombre y apellido", 0, false)]
        [TestCase("mi nxmbre y apellido", "mi nombre y apellido", 1, false)]
        [TestCase("mi nombre y apellido", "mi nombre y apellidx", 1, false)]
        [TestCase("mi nombre y xpellido", "mi nombre y apellidx", 2, false)]
        [TestCase("mi nombre y xpellido", "mi nombre y apellixx", 3, false)]
        [TestCase("one", "two", 3, false)]
        public void DiffCharsCount(string text1, string text2, int expected, bool generaException)
        {
            if (generaException)
                Assert.Throws<ArgumentException>(() => text1.DiffCharsCount(text2));
            else
                text1.DiffCharsCount(text2).AssertEqualTo(expected);
        }


        [Test]
        public void SplitInWords()
        {
            var words = "Separa en tres palabras".SplitInWords();
            words.Length.AssertEqualTo(4);
            words[0].AssertEqualTo("Separa");
            words[1].AssertEqualTo("en");
            words[2].AssertEqualTo("tres");
            words[3].AssertEqualTo("palabras");
        }


        [Test]
        public void CountOccurrences()
        {
            "Hola mis amigos".CountOccurrences("o").AssertEqualTo(2);
            "Hola mis amigos".CountOccurrences("Hola").AssertEqualTo(1);
            "Hola mis amigos".CountOccurrences("hola").AssertEqualTo(1);
        }

    }
}
