using System.Collections.Generic;
using App.Scripts.Features.Crosswords.Core;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Features.Crosswords.CrossWordGenerator.Services.Generator
{
    public interface ICrosswordGenerator
    {
        UniTask<List<LevelCrosswordData>> Generate(GenerationOptions options);
    }
}