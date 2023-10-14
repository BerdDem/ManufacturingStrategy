using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ResourceConverterBuildingData")]
    public class ResourceConverterBuildingData : ScriptableObject
    {
        [Serializable]
        public struct Resource
        {
            [Serializable]
            public struct RawMaterials
            {
                public string name;
                public float amount;
            }

            public List<RawMaterials> materials;
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