using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ResourceMarketSellData")]
    public class ResourceMarketSellData : ScriptableObject
    {
        [Serializable]
        public struct ResourceCost
        {
            public string name;
            public float cost;
        }

        public ResourceCost GetResourceCost(string resourceName)
        {
            foreach (ResourceCost resourceCost in resourcesCost)
            {
                if (resourceName == resourceCost.name)
                {
                    return resourceCost;
                }
            }
            
            throw new ArgumentException($"{resourceName} - not found");
        }

        public List<ResourceCost> resourcesCost;
    }
}