using UnityEngine;

namespace Source.Buildings
{
    public class ResourceBuilding : MonoBehaviour
    {
        private IResourceForge _resourceForge;
        private float _timeToMakeResource;

        public void Initialize(IResourceForge resourceForge)
        {
            _resourceForge = resourceForge;
        } 
        
        public void SelectResource(string resourceName)
        {
            _resourceForge.SelectResource(resourceName);
        }

        public void BuildEnable(bool enable)
        {
            _resourceForge.BuildEnable(enable);
        }

        public void Update()
        {
            _resourceForge.ResourceCreationUpdate();
        }
    }
}