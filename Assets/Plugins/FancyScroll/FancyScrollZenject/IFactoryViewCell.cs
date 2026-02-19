using App.Scripts.Libs.FancyScrollView.Sources.Runtime.Core;
using UnityEngine;

namespace App.Scripts.Libs.FancyScrollZenject
{
    public interface IFactoryViewCell
    {
        FancyCell<TItemData, TContext> Create<TItemData, TContext>(GameObject cellPrefab, Transform cellContainer) where TContext : class, new();
    }
}