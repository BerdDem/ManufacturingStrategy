using System;
using Source.Data;
using Source.View.Properties;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIResource : MonoBehaviour
    {
        private readonly IntProperty _resourceValue = new();
        private readonly SpriteProperty _spriteProperty = new();

        public void SetResource(string resourceName)
        {
            DataManager dataManager = DataManager.instance;
            dataManager.playerResourceContainer.SubscribeResourceChange(resourceName, ChangeResourceValueNotification);
            _spriteProperty.value = dataManager.gameData.resourcesData.GetResource(resourceName).sprite;
        }

        private void ChangeResourceValueNotification(float resourceValue)
        {
            _resourceValue.value = (int)resourceValue;
        }
    }
}