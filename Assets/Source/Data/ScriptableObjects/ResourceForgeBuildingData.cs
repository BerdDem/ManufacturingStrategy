using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ResourceForgeBuildingData")]
    public class ResourceForgeBuildingData : ScriptableObject
    {
        [Serializable]
        public struct Resource
        {
            public string name;
            public float amountProduced;
            public float productionTime;
        }

        public Resource GetResource(string resourceName)
        {
            foreach (Resource resource in resources)
            {
                if (resource.name == resourceName)
                {
                    return resource;
                }
            }
            
            throw new ArgumentException($"{resourceName} - not found");
        }
        
        public List<Resource> resources = new();
    }
}