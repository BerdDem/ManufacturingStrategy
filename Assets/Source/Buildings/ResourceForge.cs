using System.Collections.Generic;
using Source.Data;
using UnityEngine;

namespace Source.Buildings
{
    public class ResourceForge : IResourceForge
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
            
            _timeToMakeResource += Time.deltaTime;

            if (_makeResource.secondsToMakeOne > _timeToMakeResource)
            {
                return;
            }
            
            DataManager.instance.playerResourceContainer.AddResources(new Dictionary<string, float> {{_makeResource.name, 1}});
            _timeToMakeResource = 0;
        }
    }
}