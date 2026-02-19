using UnityEngine;

namespace App.Scripts.Libs.FancyScrollZenject.Placers
{
    public abstract class MonoPositionUpdater : MonoBehaviour
    {
        public abstract void UpdatePosition(float position);
    }
}