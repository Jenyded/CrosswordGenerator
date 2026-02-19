using App.Scripts.Infrastructure.SimpleMath;
using NUnit.Framework;

namespace App.Scripts.Tests
{
    public class FloatParserTests
    {
        [Test]
        public void SimpleInteger_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("123", out float result));
            Assert.That(result, Is.EqualTo(123f));
        }

        [Test]
        public void DotSeparator_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("12.5", out float result));
            Assert.That(result, Is.EqualTo(12.5f));
        }

        [Test]
        public void CommaSeparator_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("12,5", out float result));
            Assert.That(result, Is.EqualTo(12.5f));
        }

        [Test]
        public void TrailingSeparator_ParsesAsInteger()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("123,", out float result));
            Assert.That(result, Is.EqualTo(123f));
        }

        [Test]
        public void TrailingDot_ParsesAsInteger()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("123.", out float result));
            Assert.That(result, Is.EqualTo(123f));
        }

        [Test]
        public void LeadingSpaces_Ignored()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("   42", out float result));
            Assert.That(result, Is.EqualTo(42f));
        }

        [Test]
        public void TrailingSpaces_Ignored()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("42   ", out float result));
            Assert.That(result, Is.EqualTo(42f));
        }

        [Test]
        public void LeadingAndTrailingSpaces_Ignored()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("  3,14  ", out float result));
            Assert.That(result, Is.EqualTo(3.14f).Within(0.001f));
        }

        [Test]
        public void NegativeNumber_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("-7.5", out float result));
            Assert.That(result, Is.EqualTo(-7.5f));
        }

        [Test]
        public void PositiveSign_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("+9,1", out float result));
            Assert.That(result, Is.EqualTo(9.1f).Within(0.001f));
        }

        [Test]
        public void Zero_ReturnsZero()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("0", out float result));
            Assert.That(result, Is.EqualTo(0f));
        }

        [Test]
        public void ZeroWithFraction_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("0.25", out float result));
            Assert.That(result, Is.EqualTo(0.25f));
        }

        [Test]
        public void LeadingDot_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat(".5", out float result));
            Assert.That(result, Is.EqualTo(0.5f));
        }

        [Test]
        public void LeadingComma_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat(",75", out float result));
            Assert.That(result, Is.EqualTo(0.75f));
        }

        [Test]
        public void Null_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat(null, out _));
        }

        [Test]
        public void EmptyString_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("", out _));
        }

        [Test]
        public void OnlySpaces_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("   ", out _));
        }

        [Test]
        public void Letters_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("abc", out _));
        }

        [Test]
        public void MixedLettersAndDigits_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("12a5", out _));
        }

        [Test]
        public void TwoSeparators_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("1.2.3", out _));
        }

        [Test]
        public void TwoMixedSeparators_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("1,2.3", out _));
        }

        [Test]
        public void OnlyMinus_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("-", out _));
        }

        [Test]
        public void OnlyPlus_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat("+", out _));
        }

        [Test]
        public void OnlyDot_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat(".", out _));
        }

        [Test]
        public void OnlyComma_ReturnsFalse()
        {
            Assert.IsFalse(FloatParser.TryParseFloat(",", out _));
        }

        [Test]
        public void NegativeWithComma_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("-100,99", out float result));
            Assert.That(result, Is.EqualTo(-100.99f).Within(0.01f));
        }

        [Test]
        public void LargeNumber_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("999999", out float result));
            Assert.That(result, Is.EqualTo(999999f));
        }

        [Test]
        public void SmallFraction_ReturnsCorrectValue()
        {
            Assert.IsTrue(FloatParser.TryParseFloat("0.001", out float result));
            Assert.That(result, Is.EqualTo(0.001f).Within(0.0001f));
        }
    }
}
