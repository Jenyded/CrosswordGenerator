using UnityEngine;

namespace App.Scripts.Features.Crosswords.CrossWordGenerator.Config
{
    public class SettingsStaticGenerator : ScriptableObject
    {
        [Tooltip("Путь к папке с JSON-файлами уровней относительно Resources (например: CrosswordLevels)")]
        [SerializeField] private string levelsResourcePath = "CrosswordLevels";

        public string LevelsResourcePath => levelsResourcePath;
    }
}
