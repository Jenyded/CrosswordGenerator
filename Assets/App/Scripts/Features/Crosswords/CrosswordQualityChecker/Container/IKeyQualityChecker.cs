namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Container
{
    public interface IKeyQualityChecker
    {
        ICrosswordQualityChecker Checker { get; }
        string Key { get; }
    }
}