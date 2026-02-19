using System.Collections.Generic;
using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewModels;
using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords.Items;
using App.Scripts.Libs.FancyScrollZenject;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords
{
    public class ViewScrollCrosswordsFancy : FancyScrollViewZenject<ViewModelCrosswordLevel, ContextScrollCrosswords>
    {
        [SerializeField] private ViewItemScrollCrossword prefab;
        
        private readonly List<ViewModelCrosswordLevel> _items = new (100);


        protected override GameObject GetPrefab() => prefab.gameObject;

        public void UpdateItems(IEnumerable<ViewModelCrosswordLevel> crosswords)
        {
            _items.Clear();
            _items.AddRange(crosswords);
            UpdateScrollItems(_items);
        }
    }
}