using System.Collections.Generic;
using App.Scripts.Features.Crosswords.Core;
using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords.Items;
using App.Scripts.Infrastructure.SimplePool;
using UnityEngine;
using Zenject;

namespace App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords
{
    public class ViewCrossword : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private float cellSize = 64f;

        private readonly List<ViewItemCrosswordCell> _spawnedCells = new();
        private Vector2 _currentSize;
        private ISimplePool<ViewItemCrosswordCell> _viewPool;

        public Vector2 GetSize() => _currentSize;

        [Inject]
        public void Constructor(ISimplePool<ViewItemCrosswordCell> viewPool)
        {
            _viewPool = viewPool;
        }
        
        public void Setup(LevelCrosswordData itemData)
        {
            ClearCells();

            if (itemData == null || itemData.words == null)
                return;

            int width = itemData.size.x;
            int height = itemData.size.y;
            if (width <= 0 || height <= 0)
                return;

            var grid = itemData.BuildLetterGrid();

            float containerWidth = width * cellSize;
            float containerHeight = height * cellSize;
            _currentSize = new Vector2(containerWidth, containerHeight);
            container.sizeDelta = _currentSize;

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    var value = grid[row, col];
                    if (value == 0)
                    {
                        continue;
                    }
                    
                    var cell = _viewPool.Get();
                    cell.transform.SetParent(container);
                    cell.transform.localScale = Vector3.one;
                    cell.transform.localPosition = Vector3.zero;
                    
                    _spawnedCells.Add(cell);

                    if (cell.transform is RectTransform rect)
                    {
                        rect.anchorMin = new Vector2(0, 1);
                        rect.anchorMax = new Vector2(0, 1);
                        rect.pivot = new Vector2(0.5f, 0.5f);
                        rect.sizeDelta = new Vector2(cellSize, cellSize);
                        rect.anchoredPosition = new Vector2(
                            col * cellSize + cellSize * 0.5f,
                            -(row * cellSize + cellSize * 0.5f)
                        );
                    }

                    cell.Setup(value);
                }
            }
        }

        private void OnDisable()
        {
            _currentSize = Vector2.zero;
        }

        private void ClearCells()
        {
            foreach (var cell in _spawnedCells)
            {
                _viewPool.Return(cell);
            }
            _spawnedCells.Clear();
        }
    }
}
