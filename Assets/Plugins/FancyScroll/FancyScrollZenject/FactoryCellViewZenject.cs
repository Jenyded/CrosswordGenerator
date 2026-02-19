using System.Collections.Generic;
using System.Linq;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.Core;
using UnityEngine;
using Zenject;

namespace App.Scripts.Libs.FancyScrollZenject
{
    public class FactoryCellViewZenject : IFactoryViewCell
    {
        private readonly DiContainer _diContainer;
        private readonly List<IStepSetupView> _steps;

        public FactoryCellViewZenject(DiContainer diContainer, IEnumerable<IStepSetupView> steps)
        {
            _diContainer = diContainer;
            _steps = steps.ToList();
        }
        
        public FancyCell<TItemData, TContext> Create<TItemData, TContext>(GameObject cellPrefab, Transform cellContainer) where TContext : class, new()
        {
            var view = _diContainer.InstantiatePrefab(cellPrefab, cellContainer).GetComponent<FancyCell<TItemData, TContext>>();

            SetupView(view);
            
            if (ReferenceEquals(view, null) )
            {
                throw new MissingComponentException(string.Format(
                    "FancyCell<{0}, {1}> component not found in {2}.",
                    typeof(TItemData).FullName, typeof(TContext).FullName, cellPrefab.name));
            }

            return view;
        }

        private void SetupView<TItemData, TContext>(FancyCell<TItemData, TContext> view) where TContext : class, new()
        {
            foreach (IStepSetupView stepSetupView in _steps)
            {
                stepSetupView.OnSetup(view.gameObject);
            }
        }
    }
}