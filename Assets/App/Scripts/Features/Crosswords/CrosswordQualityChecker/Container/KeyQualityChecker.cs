namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Container
{
    public class KeyQualityChecker<T> : IKeyQualityChecker where T : ICrosswordQualityChecker
    {
        public ICrosswordQualityChecker Checker { get; }
        public string Key { get; }

        public KeyQualityChecker(T checker, string key)
        {
            Checker = checker;
            Key = key;
        }
    }
}