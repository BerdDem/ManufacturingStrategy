using Source.View.Bindings;
using Source.View.Properties.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Source.View.Properties
{
    public class IntChangeColorBinding : Binding<IIntProperty>
    {
        [SerializeField] private Color _color = Color.white;
        [SerializeField] private int _key;
        [SerializeField] private bool _invert;

        private Image _image;
        private Color _defaultColor;
        
        protected override void Awake()
        {
            _image = GetComponent<Image>();
            _defaultColor = _image.color;
            
            base.Awake();
        }

        protected override void OnUpdateValue()
        {
            base.OnUpdateValue();
            
            bool active = _key == _property.value;

            if (_invert)
            {
                active = !active;
            }

            _image.color = active ? _color : _defaultColor;
        }
    }
}