using System.Collections.Generic;
using UnityEngine;

namespace Source.Buildings
{
    public class ResourceForge : IResourceForge
    {
        private MakeResource _makeResource;
        private float _timeToMakeResource;
        
        public void SelectResource(string resourceName, MakeResource makeResource)
        {
            _makeResource = makeResource;
        }

        public void ResourceCreationUpdate()
        {
            _timeToMakeResource += Time.deltaTime;

            if (_makeResource.secondsToMakeOne > _timeToMakeResource)
            {
                return;
            }
            
            GameManager.instance.playerResourceContainer.AddResources(new Dictionary<string, float> {{_makeResource.name, 1}});
            _timeToMakeResource = 0;
        }
    }
}