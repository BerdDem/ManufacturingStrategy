using Source.View.Properties.Interfaces;
using TMPro;

namespace Source.View.Bindings
{
    public class TextBinding : Binding<IStringProperty>
    {
        private TextMeshProUGUI _textMeshPro;
        
        protected override void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            
            base.Awake();
        }

        protected override void OnUpdateValue()
        {
            _textMeshPro.text = _property.value;
        }
    }
}