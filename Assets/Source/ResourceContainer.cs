using System;
using System.Collections.Generic;

namespace Source
{
    public class ResourceContainer
    {
        private Dictionary<string, float> _resources = new();
        private Dictionary<string, List<Action<float>>> _resourceChangeEvents;

        public void InitializeResources(Dictionary<string, float> resources)
        {
            _resources = resources;

            foreach (KeyValuePair<string, float> resource in _resources)
            {
                _resourceChangeEvents.Add(resource.Key, new List<Action<float>>());
            }
        }

        public void AddResources(Dictionary<string, float> resources)
        {
            foreach (KeyValuePair<string, float> resource in resources)
            {
                _resources[resource.Key] += resource.Value;
            }
        }

        public void DecreaseResources(Dictionary<string, float> resources)
        {
            foreach (KeyValuePair<string, float> resource in resources)
            {
                _resources[resource.Key] -= resource.Value;
            }
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

        public void SubscribeResourceChange(string resourceName, Action<float> changeResourceNotification)
        {
            _resourceChangeEvents[resourceName].Add(changeResourceNotification);
        }

        public void UnsubscribeResourceChange(string resourceName, Action<float> changeResourceNotification)
        {
            _resourceChangeEvents[resourceName].Remove(changeResourceNotification);
        }
    }
}