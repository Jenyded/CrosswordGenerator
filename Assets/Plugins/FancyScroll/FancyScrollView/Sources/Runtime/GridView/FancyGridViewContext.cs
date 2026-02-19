/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.Scroller;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.ScrollRect;
using UnityEngine;

namespace App.Scripts.Libs.FancyScrollView.Sources.Runtime.GridView
{
    /// <summary>
    /// <see cref="FancyGridView{TItemData, TContext}"/> のコンテキスト基底クラス.
    /// </summary>
    public class FancyGridViewContext : IFancyGridViewContext
    {
        ScrollDirection IFancyScrollRectContext.ScrollDirection { get; set; }
        Func<(float ScrollSize, float ReuseMargin)> IFancyScrollRectContext.CalculateScrollSize { get; set; }
        GameObject IFancyCellGroupContext.CellTemplate { get; set; }
        Func<int> IFancyCellGroupContext.GetGroupCount { get; set; }
        Func<float> IFancyGridViewContext.GetStartAxisSpacing { get; set; }
        Func<float> IFancyGridViewContext.GetCellSize { get; set; }
    }
}
