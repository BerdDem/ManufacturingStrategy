using Source.View.Properties.Interfaces;

namespace Source.View.Properties
{
    public class BoolProperty : Property<bool>, IBoolProperty
    {
        bool IBoolProperty.value => value;
    }
}