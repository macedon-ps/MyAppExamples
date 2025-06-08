using GenericSequenceGenerator.Interfaces;
using GenericSequenceGenerator.Models;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace GenericSequenceGenerator.Tests;

[TestFixture]
public class CharSequenceGeneratorTests
{
    [Test]
    public void FourthSequenceGenerator_Should_Generate_Correct_Sequence()
    {
        var generator = new CharSequenceGenerator('A', 'B');
        var expectedSequence = new List<char>
        {
            'A',
            'B',
            'B',
            'C',
            'D',
            'F',
            'I',
            'N',
            'V',
            'I'
        };

        var actualSequence = new List<char> { generator.Previous, generator.Current };
        for (int i = 0; i < 8; i++)
        {
            actualSequence.Add(generator.Next);
        }

        CollectionAssert.AreEqual(expectedSequence, actualSequence);
    }

    [Test]
    public void FourthSequenceGenerator_Should_Generate_Correct_Sequence_With_Wrap_Around()
    {
        var generator = new CharSequenceGenerator('Y', 'Z');
        var expectedSequence = new List<char>
        {
            'Y',
            'Z',
            'X',
            'W',
            'T',
            'P',
            'I',
            'X',
            'F',
            'C'
        };

        var actualSequence = new List<char> { generator.Previous, generator.Current };
        for (int i = 0; i < 8; i++)
        {
            actualSequence.Add(generator.Next);
        }

        CollectionAssert.AreEqual(expectedSequence, actualSequence);
    }

    [Test]
    public void FourthSequenceGenerator_Should_Behave_Polymorphically()
    {
        ISequenceGenerator<char> generator = new CharSequenceGenerator('K', 'L');
        var expectedSequence = new List<char>
        {
            'K',
            'L',
            'V',
            'G',
            'B',
            'H',
            'I'
        };

        var actualSequence = new List<char> { generator.Previous, generator.Current };
        for (int i = 0; i < 5; i++)
        {
            actualSequence.Add(generator.Next);
        }

        CollectionAssert.AreEqual(expectedSequence, actualSequence);
    }
}
