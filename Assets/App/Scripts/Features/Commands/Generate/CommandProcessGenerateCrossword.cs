using App.Scripts.Features.Crosswords.CrosswordGallery;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Config;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Services.Generator;
using App.Scripts.Infrastructure.Logger.Interfaces;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Features.Commands.Generate
{
    public class CommandProcessGenerateCrossword : ICommandProcessGenerateCrossword
    {
        private readonly ICrosswordGenerator _generator;
        private readonly ICrosswordGenerateOptionsProvider _optionsProvider;
        private readonly ICrosswordGalleryHolder _crosswordGalleryHolder;
        private readonly IAppLogger _logger;

        public CommandProcessGenerateCrossword(ICrosswordGenerator generator,
            ICrosswordGenerateOptionsProvider optionsProvider,
            ICrosswordGalleryHolder crosswordGalleryHolder,
            IAppLogger logger)
        {
            _generator = generator;
            _optionsProvider = optionsProvider;
            _crosswordGalleryHolder = crosswordGalleryHolder;
            _logger = logger;
        }
        
        public async UniTask Execute()
        {
            var crosswords = await _generator.Generate(_optionsProvider.Options);
            _logger.Log($"StateProcessGenerate: generated {crosswords.Count} level(s).");
            foreach (var level in crosswords)
                _logger.Log(level.ToString());
            _crosswordGalleryHolder.Setup(crosswords);
        }
    }
}