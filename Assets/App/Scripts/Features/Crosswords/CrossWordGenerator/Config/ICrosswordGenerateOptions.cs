using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;

namespace App.Scripts.Features.Crosswords.CrossWordGenerator.Config
{
    public interface ICrosswordGenerateOptionsProvider
    {
        GenerationOptions Options { get; }
        
        void Setup(GenerationOptions options);
    }
}