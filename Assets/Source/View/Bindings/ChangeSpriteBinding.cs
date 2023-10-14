using Source.View.Properties.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Source.View.Bindings
{
    public class ChangeSpriteBinding : Binding<ISpriteProperty>
    {
        private Image _image;
        
        protected override void Awake()
        {
            _image = GetComponent<Image>();
            
            base.Awake();
        }

        protected override void OnUpdateValue()
        {
            base.OnUpdateValue();

            _image.sprite = _property.value;
        }
    }
}