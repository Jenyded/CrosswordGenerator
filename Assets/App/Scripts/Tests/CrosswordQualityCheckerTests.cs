using App.Scripts.Features.Crosswords.Core;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker.Checkers;
using NUnit.Framework;
using UnityEngine;

namespace App.Scripts.Tests
{
    public class CrosswordQualityCheckerTests
    {
        private static LevelCrosswordData CreateCrossword(Vector2Int size, params (string word, int gridIndex, bool isVertical)[] words)
        {
            var data = new LevelCrosswordData { id = "test", size = size };
            foreach (var (word, gridIndex, isVertical) in words)
                data.words.Add(new WordData { word = word, gridIndex = gridIndex, isVertical = isVertical });
            return data;
        }

        #region QualityCheckerDensity

        [Test]
        public void Density_Null_ReturnsZero()
        {
            var checker = new QualityCheckerDensity();
            Assert.That(checker.GetMark(null), Is.EqualTo(0f));
        }

        [Test]
        public void Density_ZeroSize_ReturnsZero()
        {
            var checker = new QualityCheckerDensity();
            var data = CreateCrossword(Vector2Int.zero);
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void Density_EmptyGrid_ReturnsZero()
        {
            var checker = new QualityCheckerDensity();
            var data = CreateCrossword(new Vector2Int(3, 3));
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void Density_HalfFilled_ReturnsHalf()
        {
            var checker = new QualityCheckerDensity();
            // 2x2, one horizontal word "AB" at (0,0) -> 2 cells of 4
            var data = CreateCrossword(new Vector2Int(2, 2), ("AB", 0, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(0.5f));
        }

        [Test]
        public void Density_FullGrid_ReturnsOne()
        {
            var checker = new QualityCheckerDensity();
            // 2x2: "AB" at (0,0), "CD" at (1,0)
            var data = CreateCrossword(new Vector2Int(2, 2),
                ("AB", 0, false),
                ("CD", 2, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        [Test]
        public void Density_OneCell_ReturnsCorrectFraction()
        {
            var checker = new QualityCheckerDensity();
            var data = CreateCrossword(new Vector2Int(5, 5), ("X", 12, false)); // center 2*5+2=12
            Assert.That(checker.GetMark(data), Is.EqualTo(1f / 25f));
        }

        #endregion

        #region QualityCheckerCenterBias

        [Test]
        public void CenterBias_Null_ReturnsZero()
        {
            var checker = new QualityCheckerCenterBias();
            Assert.That(checker.GetMark(null), Is.EqualTo(0f));
        }

        [Test]
        public void CenterBias_ZeroSize_ReturnsZero()
        {
            var checker = new QualityCheckerCenterBias();
            var data = CreateCrossword(Vector2Int.zero);
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void CenterBias_EmptyGrid_ReturnsZero()
        {
            var checker = new QualityCheckerCenterBias();
            var data = CreateCrossword(new Vector2Int(3, 3));
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void CenterBias_SingleCellInCenter_ReturnsOne()
        {
            var checker = new QualityCheckerCenterBias();
            // 3x3 center is index 4 (row 1, col 1)
            var data = CreateCrossword(new Vector2Int(3, 3), ("X", 4, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        [Test]
        public void CenterBias_SingleCellInCorner_LowerThanCenter()
        {
            var checker = new QualityCheckerCenterBias();
            var dataCenter = CreateCrossword(new Vector2Int(3, 3), ("X", 4, false));
            var dataCorner = CreateCrossword(new Vector2Int(3, 3), ("X", 0, false));
            float markCenter = checker.GetMark(dataCenter);
            float markCorner = checker.GetMark(dataCorner);
            Assert.That(markCorner, Is.LessThan(markCenter));
            Assert.That(markCenter, Is.EqualTo(1f));
        }

        [Test]
        public void CenterBias_1x1_ReturnsOne()
        {
            var checker = new QualityCheckerCenterBias();
            var data = CreateCrossword(new Vector2Int(1, 1), ("X", 0, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        #endregion

        #region QualityCheckerSymmetry

        [Test]
        public void Symmetry_Null_ReturnsZero()
        {
            var checker = new QualityCheckerSymmetry();
            Assert.That(checker.GetMark(null), Is.EqualTo(0f));
        }

        [Test]
        public void Symmetry_ZeroSize_ReturnsZero()
        {
            var checker = new QualityCheckerSymmetry();
            var data = CreateCrossword(Vector2Int.zero);
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void Symmetry_EmptyGrid_ReturnsOne()
        {
            var checker = new QualityCheckerSymmetry();
            var data = CreateCrossword(new Vector2Int(2, 2));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        [Test]
        public void Symmetry_Full2x2Symmetric_ReturnsOne()
        {
            var checker = new QualityCheckerSymmetry();
            // Rows [AB] and [AB]: horizontal symmetry; cols [A,A] and [B,B]: vertical
            var data = CreateCrossword(new Vector2Int(2, 2),
                ("AB", 0, false),
                ("AB", 2, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        [Test]
        public void Symmetry_OnlyTopLeft_ReturnsZero()
        {
            var checker = new QualityCheckerSymmetry();
            var data = CreateCrossword(new Vector2Int(2, 2), ("A", 0, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void Symmetry_HorizontalSymmetric_VerticalNot_ReturnsHalf()
        {
            var checker = new QualityCheckerSymmetry();
            // 2x2: fill (0,0) and (1,0) — symmetric by horizontal axis, not by vertical
            // Row 0: [X, ]  Row 1: [X, ]  -> mirror H: row1 mirrors row0, same; mirror V: col1 mirrors col0 -> (0,1) and (1,1) must match (0,0) and (1,0). So (0,1),(1,1) empty - OK. So we have horizontal symmetry (rows 0 and 1 match), vertical: col0 has X,X col1 has 0,0 - symmetric. So both? Let me recalc.
            // Grid: [X, ]  [X, ]  -> Horizontal: row 0 [X, ] vs row 1 [X, ] -> same. Vertical: col 0 [X,X] vs col 1 [ , ] -> not same. So 0.5.
            var data = CreateCrossword(new Vector2Int(2, 2),
                ("A", 0, false),
                ("B", 2, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(0.5f));
        }

        [Test]
        public void Symmetry_VerticalSymmetric_HorizontalNot_ReturnsHalf()
        {
            var checker = new QualityCheckerSymmetry();
            // 2x2: fill (0,0) and (0,1) — symmetric by vertical axis
            var data = CreateCrossword(new Vector2Int(2, 2), ("AB", 0, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(0.5f));
        }

        [Test]
        public void Symmetry_FullSymmetric3x3_ReturnsOne()
        {
            var checker = new QualityCheckerSymmetry();
            // Grid: row0 "AXA", row1 "XXX", row2 "AXA" — symmetric both ways
            var data = CreateCrossword(new Vector2Int(3, 3),
                ("AXA", 0, false),
                ("XXX", 3, false),
                ("AXA", 6, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        #endregion

        #region QualityCheckerDirectionBalance

        [Test]
        public void DirectionBalance_Null_ReturnsZero()
        {
            var checker = new QualityCheckerDirectionBalance();
            Assert.That(checker.GetMark(null), Is.EqualTo(0f));
        }

        [Test]
        public void DirectionBalance_ZeroSize_ReturnsZero()
        {
            var checker = new QualityCheckerDirectionBalance();
            var data = CreateCrossword(Vector2Int.zero);
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void DirectionBalance_EmptyGrid_ReturnsZero()
        {
            var checker = new QualityCheckerDirectionBalance();
            var data = CreateCrossword(new Vector2Int(3, 3));
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void DirectionBalance_OnlyHorizontal_ReturnsZero()
        {
            var checker = new QualityCheckerDirectionBalance();
            var data = CreateCrossword(new Vector2Int(5, 5),
                ("ABC", 0, false),
                ("DE", 5, false));
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void DirectionBalance_OnlyVertical_ReturnsZero()
        {
            var checker = new QualityCheckerDirectionBalance();
            var data = CreateCrossword(new Vector2Int(5, 5),
                ("ABC", 0, true),
                ("DE", 1, true));
            Assert.That(checker.GetMark(data), Is.EqualTo(0f));
        }

        [Test]
        public void DirectionBalance_EqualLengths_ReturnsOne()
        {
            var checker = new QualityCheckerDirectionBalance();
            // 3 horizontal cells + 3 vertical cells = perfect balance
            var data = CreateCrossword(new Vector2Int(5, 5),
                ("ABC", 0, false),
                ("DEF", 1, true));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        [Test]
        public void DirectionBalance_SlightImbalance_ReturnsBetweenZeroAndOne()
        {
            var checker = new QualityCheckerDirectionBalance();
            // h=4, v=2, total=6, diff=2 => 1 - 2/6 = 2/3
            var data = CreateCrossword(new Vector2Int(5, 5),
                ("ABCD", 0, false),
                ("EF", 1, true));
            float mark = checker.GetMark(data);
            Assert.That(mark, Is.EqualTo(2f / 3f).Within(0.0001f));
        }

        [Test]
        public void DirectionBalance_IgnoresEmptyWords()
        {
            var checker = new QualityCheckerDirectionBalance();
            var data = CreateCrossword(new Vector2Int(5, 5),
                ("AB", 0, false),
                ("", 5, true),
                ("CD", 1, true));
            Assert.That(checker.GetMark(data), Is.EqualTo(1f));
        }

        #endregion
    }
}
