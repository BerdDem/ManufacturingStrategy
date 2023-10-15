using System;
using System.Collections.Generic;

namespace Source
{
    public class ResourceContainer
    {
        public Dictionary<string, float> resources => _resources;

        private Dictionary<string, float> _resources;
        private readonly Dictionary<string, Action<float>> _resourceChangeEvents = new();

        public void InitializeResources(Dictionary<string, float> resources)
        {
            _resources = resources;

            foreach (KeyValuePair<string, float> resource in _resources)
            {
                _resourceChangeEvents.Add(resource.Key, null);
            }
        }

        public void AddResources(Dictionary<string, float> resources)
        {
            foreach (KeyValuePair<string, float> resource in resources)
            {
                _resources[resource.Key] += resource.Value;
                
                _resourceChangeEvents[resource.Key].Invoke(_resources[resource.Key]);
            }
        }
        
        public void AddResources(string name, float amount)
        {
            _resources[name] += amount;
            _resourceChangeEvents[name].Invoke(_resources[name]);
        }

        public void DecreaseResources(Dictionary<string, float> resources)
        {
            foreach (KeyValuePair<string, float> resource in resources)
            {
                _resources[resource.Key] -= resource.Value;
                _resourceChangeEvents[resource.Key].Invoke(_resources[resource.Key]);
            }
        }

        public void DecreaseResources(string name, float amount)
        {
            _resources[name] -= amount;
            _resourceChangeEvents[name].Invoke(_resources[name]);
        }

        public float GetResourceValue(string resourceName)
        {
            return _resources[resourceName];
        }

        public bool CheckPrice(Dictionary<string, float> resources)
        {
            foreach (KeyValuePair<string, float> resource in resources)
            {
                if (_resources[resource.Key] < resource.Value)
                {
                    return false;
                }
            }

            return true;
        }
        
        public bool CheckPrice(string resourceName, float amount)
        {
            return _resources[resourceName] > amount;
        }

        public void SubscribeResourceChange(string resourceName, Action<float> changeResourceNotification)
        {
            _resourceChangeEvents[resourceName] += changeResourceNotification;
        }

        public void UnsubscribeResourceChange(string resourceName, Action<float> changeResourceNotification)
        {
            _resourceChangeEvents[resourceName] -= changeResourceNotification;
        }
    }
}