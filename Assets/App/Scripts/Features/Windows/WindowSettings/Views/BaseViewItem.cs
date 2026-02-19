using UnityEngine;

namespace App.Scripts.Features.Windows.WindowSettings.Views
{
    public abstract class BaseViewItemBase : MonoBehaviour
    {
        public abstract void Setup(object model);
        public virtual void Clear() { }
    }

    public abstract class BaseViewItem<T> : BaseViewItemBase
    {
        public override void Setup(object model)
        {
            if (model is T typedModel)
            {
                OnSetup(typedModel);
            }
            
        }

        protected abstract void OnSetup(T typedModel);
    }
}