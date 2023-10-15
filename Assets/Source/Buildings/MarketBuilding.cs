using Source.Data;
using Source.Data.ScriptableObjects;
using UnityEngine;

namespace Source.Buildings
{
    public class MarketBuilding : MonoBehaviour
    {
        private const string GoldResourceName = "gold";
        private ResourceMarketSellData _resourceMarketSellData;
        private ResourceContainer _resourceContainer;

        private void Start()
        {
            _resourceMarketSellData = DataManager.instance.gameData.resourceMarketSellData;
            _resourceContainer = DataManager.instance.playerResourceContainer;
        }

        public void SellResource(string resourceName)
        {
            if (!_resourceContainer.CheckPrice(resourceName, 1))
            {
                return;
            }
            
            _resourceContainer.DecreaseResources(resourceName, 1);
            _resourceContainer.AddResources(GoldResourceName, _resourceMarketSellData.GetResourceCost(resourceName).cost);
        }
    }
}