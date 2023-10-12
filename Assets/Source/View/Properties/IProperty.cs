using System;

namespace Source.View.Properties
{
    public interface IProperty
    {
        event Action ValueChanged;
    }
}