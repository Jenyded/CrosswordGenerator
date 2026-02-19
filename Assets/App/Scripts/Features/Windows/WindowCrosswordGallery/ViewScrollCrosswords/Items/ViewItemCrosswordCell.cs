using TMPro;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords.Items
{
    public class ViewItemCrosswordCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text labelChar;

        public void Setup(char value)
        {
            labelChar.text = value.ToString();
        }
    }
}