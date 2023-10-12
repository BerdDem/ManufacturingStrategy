using Source.View.Properties.Interfaces;
using UnityEngine;

namespace Source.View.Bindings
{
    public class VisibilityBoolBinding : Binding<IBoolProperty>
    {
        [SerializeField] private bool _invert;

        protected override void OnUpdateValue()
        {
            base.OnUpdateValue();

            bool value = _property.value;
            
            if (_invert)
            {
                value = !value;
            }

            gameObject.SetActive(value);
        }
    }
}