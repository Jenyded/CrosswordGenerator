using System;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.Core;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.GridView;
using UnityEngine;
using Zenject;

namespace App.Scripts.Libs.FancyScrollZenject
{
    public abstract class FancyGridViewZenject<TItemData, TContext> : FancyGridView<TItemData, TContext> where TContext : class, IFancyGridViewContext, new()
    {
        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        protected abstract class DefaultCellGroupZenject : FancyCellGroup<TItemData, TContext>
        {
            private DiContainer _diContainer;

            [Inject]
            private void Construct(DiContainer container)
            {
                _diContainer = container;
            }
            
            protected override FancyCell<TItemData, TContext>[] InstantiateCells()
            {
                var groupCount = Context.GetGroupCount();
                var result = new FancyCell<TItemData, TContext>[groupCount];
                for (int i = 0; i < groupCount; i++)
                {
                    var viewCell = _diContainer.InstantiatePrefab(Context.CellTemplate, transform).GetComponent<FancyCell<TItemData, TContext>>();
                    result[i] = viewCell;
                }

                return result;
            }
        }
        
        protected override FancyCell<TItemData[], TContext> CreateCell()
        {
            var viewCell = _diContainer.InstantiatePrefab(CellPrefab, cellContainer).GetComponent<FancyCell<TItemData[], TContext>>();
            
            if (ReferenceEquals(viewCell, null) )
            {
                throw new MissingComponentException(string.Format(
                    "FancyCell<{0}, {1}> component not found in {2}.",
                    typeof(TItemData).FullName, typeof(TContext).FullName, CellPrefab.name));
            }
            
            OnCellCreated(viewCell);
            
            return viewCell;
        }
    }
}