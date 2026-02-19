using UnityEngine;

namespace App.Scripts.Infrastructure.SimpleWindows
{
    public class WindowViewContainer : MonoBehaviour
    {
        [SerializeField] private RectTransform dialogContainer;

        public RectTransform Container => dialogContainer;
    }
}