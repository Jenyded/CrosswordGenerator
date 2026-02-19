using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;

namespace App.Scripts.Features.Crosswords.CrossWordGenerator.Config
{
    public class CrosswordOptionProvider : ICrosswordGenerateOptionsProvider
    {
        public GenerationOptions Options { get; private set; }
        
        public void Setup(GenerationOptions options)
        {
            Options = options;
        }
    }
}