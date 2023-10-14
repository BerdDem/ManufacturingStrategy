using System.Collections.Generic;
using Source.Data;
using UnityEngine;

namespace Source.Buildings
{
    public class ResourceConverter : IResourceForge
    {
        private MakeResource _makeResource;
        private float _timeToMakeResource;
        private bool _processing;

        public void ProcessingToggle()
        {
            _processing = !_processing;
        }

        public void SelectResource(string resourceName, MakeResource makeResource)
        {
            _makeResource = makeResource;
        }

        public void ResourceCreationUpdate()
        {
            if (!_processing)
            {
                return;
            }
            
            ResourceContainer resourceContainer = DataManager.instance.playerResourceContainer;
            
            // Add resource which need for make this resource, get that and price
            // if (!resourceContainer.CheckPrice(_makeResource.rawResources))
            // {
            //     return;
            // }
            
            _timeToMakeResource += Time.deltaTime;

            if (_makeResource.secondsToMakeOne > _timeToMakeResource)
            {
                return;
            }

            // resourceContainer.DecreaseResources(_makeResource.rawResources);
            resourceContainer.AddResources(new Dictionary<string, float> {{_makeResource.name, 1}});
            
            _timeToMakeResource = 0;
        }
    }
}