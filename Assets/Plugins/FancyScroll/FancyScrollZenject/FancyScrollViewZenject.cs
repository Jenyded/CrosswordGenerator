using System.Collections.Generic;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.Core;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.Scroller;
using UnityEngine;
using Zenject;

namespace App.Scripts.Libs.FancyScrollZenject
{
    
    public abstract class FancyScrollViewZenject<TItemData> : FancyScrollViewZenject<TItemData, NullContext>
    {
    }
    
    public abstract class FancyScrollViewZenject<TItemData, TContext> : FancyScrollView<TItemData, TContext> where TContext : class, new()
    {
        protected override GameObject CellPrefab => GetPrefab();

        [SerializeField] private Scroller scroller;
        private DiContainer _container;

        protected Scroller Scroller => scroller;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        protected abstract GameObject GetPrefab();

        protected override void Initialize()
        {
            base.Initialize();
            scroller.OnValueChanged(UpdatePosition);
        }

        protected void UpdateScrollItems(List<TItemData> items)
        {
            UpdateContents(items);
            Scroller.SetTotalCount(items.Count);
        }
        
        protected override FancyCell<TItemData, TContext> CreateCell()
        {
            var cellView = _container.InstantiatePrefabForComponent<FancyCell<TItemData, TContext>>(CellPrefab, cellContainer);

            OnCellCreated(cellView);
            
            return cellView;
        }
    }
}