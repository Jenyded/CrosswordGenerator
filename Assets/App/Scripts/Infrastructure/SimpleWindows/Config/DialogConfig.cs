using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.SimpleWindows.Window;
using UnityEngine;

namespace App.Scripts.Infrastructure.SimpleWindows.Config
{
    public class DialogConfig : ScriptableObject
    {
        public List<DialogCreateInfo> dialogs = new List<DialogCreateInfo>();
    }

    [Serializable]
    public class DialogCreateInfo
    {
        public string id;
        public WindowView dialogPrefab;
    }
}