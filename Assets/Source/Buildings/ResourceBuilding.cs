using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Buildings
{
    //remove
    [Serializable]
    public struct MakeResource
    {
        public string name;
        public float secondsToMakeOne;
    }
    
    public class ResourceBuilding : MonoBehaviour
    {
        //remove
        [SerializeField] private MakeResource _makeResource;

        private IResourceForge _resourceForge;
        private float _timeToMakeResource;

        public void Initialize(IResourceForge resourceForge)
        {
            _resourceForge = resourceForge;
        }

        public void SelectResource(string resourceName)
        {
            _resourceForge.SelectResource(resourceName, _makeResource);
        }

        public void ProcessingToggle()
        {
            _resourceForge.ProcessingToggle();
        }
        
        private void Update()
        {
            _resourceForge.ResourceCreationUpdate();
        }
    }
}