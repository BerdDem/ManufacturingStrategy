using System.Collections.Generic;
using Source.Data;
using Source.Data.ScriptableObjects;
using UnityEngine;

namespace Source.Buildings
{
    public class ResourceForge : IResourceForge
    {
        private ResourceForgeBuildingData.Resource _resourceData;
        
        private float _timeToMakeResource;
        private bool _enable;

        public void BuildEnable(bool enable)
        {
            _enable = enable;
        }

        public void SelectResource(string resourceName)
        {
            _resourceData = DataManager.instance.gameData.resourceForgeBuildingData.GetResource(resourceName);
            _timeToMakeResource = 0;
        }

        public void ResourceCreationUpdate()
        {
            if (!_enable)
            {
                return;
            }
            
            _timeToMakeResource += Time.deltaTime;

            if (_resourceData.productionTime > _timeToMakeResource)
            {
                return;
            }
            
            DataManager.instance.playerResourceContainer.AddResources(new Dictionary<string, float> {{_resourceData.name, _resourceData.amountProduced}});
            _timeToMakeResource = 0;
        }
    }
}