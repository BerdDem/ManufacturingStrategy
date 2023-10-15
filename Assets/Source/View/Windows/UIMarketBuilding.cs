using System.Collections.Generic;
using Source.Buildings;
using Source.Data;
using Source.Data.ScriptableObjects;
using Source.View.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Source.View.Windows
{
    public class UIMarketBuilding : UIBuilding
    {
        [SerializeField] private MarketBuilding _marketBuilding;
        [SerializeField] private UIResourceSelector _uiResourceSelector;
        [SerializeField] private Button _sellButton;

        private readonly SpriteProperty _resourceSprite = new();
        private string _selectedResource;

        private void Start()
        {
            _sellButton.onClick.AddListener(OnResourceSell);
            _uiResourceSelector.resourceChangeEvent += ResourceChangeEvent;

            List<string> resourceNames = new();
            foreach (ResourceMarketSellData.ResourceCost resourceCost in DataManager.instance.gameData.resourceMarketSellData.resourcesCost)
            {
                resourceNames.Add(resourceCost.name);
            }
            
            _uiResourceSelector.SetResources(resourceNames);
        }

        private void ResourceChangeEvent(string resourceName)
        {
            _selectedResource = resourceName;
            _resourceSprite.value = DataManager.instance.gameData.resourcesData.GetResource(resourceName).sprite;
        }

        private void OnResourceSell()
        {
            _marketBuilding.SellResource(_selectedResource);
        }
    }
}