using UnityEngine;

namespace Source.View.Properties.Interfaces
{
    public interface ISpriteProperty : IProperty
    {
        Sprite value { get; }
    }
}