using System.Linq;
using App.Scripts.Features.Commands.PrepareGame;
using App.Scripts.Features.Crosswords.CrosswordGallery;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker;
using App.Scripts.Features.Windows;
using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewModels;
using App.Scripts.Infrastructure.SimpleWindows;
using App.Scripts.Infrastructure.SimpleWindows.Window;

namespace App.Scripts.Features.Commands.Gallery
{
    public class RouterShowCrosswordGallery : IRouterShowCrosswordGallery
    {
        private readonly IWindowNavigator _windowNavigator;
        private readonly ICrosswordGalleryHolder _crosswordGalleryHolder;
        private readonly ICommandNavigateToMenu _commandNavigateToMenu;
        private readonly ICrosswordQualityChecker _qualityChecker;

        public RouterShowCrosswordGallery(IWindowNavigator windowNavigator, 
            ICrosswordGalleryHolder crosswordGalleryHolder, 
            ICommandNavigateToMenu commandNavigateToMenu, 
            ICrosswordQualityChecker qualityChecker)
        {
            _windowNavigator = windowNavigator;
            _crosswordGalleryHolder = crosswordGalleryHolder;
            _commandNavigateToMenu = commandNavigateToMenu;
            _qualityChecker = qualityChecker;
        }
        
        public WindowView Create()
        {
            var window = _windowNavigator.CreateWindow(KeysWindows.WindowCrosswordGallery);
            
            var viewModel = new ViewModelCrosswordGallery();
            viewModel.Crosswords = _crosswordGalleryHolder.Crosswords.
                Select(x => new ViewModelCrosswordLevel
                {
                    Level = x,
                    Quality = _qualityChecker.GetMark(x)
                }).ToList();
            window.Context.AddComponent(viewModel);
            
            window.GetBehavior<WindowBehaviorButtons>().SetupButton(KeysButtons.ButtonClose, _commandNavigateToMenu);

            return window;
        }
    }
}