using System.Collections.Generic;
using Source.Data;
using Source.Data.ScriptableObjects;
using UnityEngine;

namespace Source.Buildings
{
    public class ResourceConverter : IResourceForge
    {
        private List<ResourceConverterBuildingData.Resource.RawMaterials> _materials;

        private ResourceConverterBuildingData.Resource _resourceData;
        private float _timeToMakeResource;
        private bool _enable;

        public void BuildEnable(bool enable)
        {
            _enable = enable;
        }

        public void SelectResource(string resourceName)
        {
            _resourceData = DataManager.instance.gameData.resourceConverterBuildingData.GetResource(resourceName);

            _materials = _resourceData.materials;
            _timeToMakeResource = 0;
        }

        public void ResourceCreationUpdate()
        {
            if (!_enable)
            {
                return;
            }
            
            ResourceContainer resourceContainer = DataManager.instance.playerResourceContainer;
            
            if (!CheckPrice())
            {
                return;
            }
            
            _timeToMakeResource += Time.deltaTime;

            if (_resourceData.productionTime > _timeToMakeResource)
            {
                return;
            }

            foreach (ResourceConverterBuildingData.Resource.RawMaterials material in _resourceData.materials)
            {
                resourceContainer.DecreaseResources(material.name, material.amount);
            }
            resourceContainer.AddResources(new Dictionary<string, float> {{_resourceData.name, _resourceData.amountProduced}});
            
            _timeToMakeResource = 0;
        }

        public bool CheckPrice()
        {
            foreach (ResourceConverterBuildingData.Resource.RawMaterials material in _materials)
            {
                if (!DataManager.instance.playerResourceContainer.CheckPrice(material.name, material.amount))
                {
                    return false;
                }
            }

            return true;
        }
    }
}