using Source.View.Properties.Interfaces;
using Sources.Tools;

namespace Source.View.Properties
{
    public class IntProperty : Property<int>, IIntProperty, IStringProperty
    {
        string IStringProperty.value => value >= 10000
            ? value.ToString("N0", UITextFormatter.cultureNumber)
            : value.ToString();
    }
}