using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ResourceConverterBuildingData")]
    public class ResourceConverterBuildingData : ScriptableObject
    {
        [Serializable]
        public struct Resource
        {
            public struct RawMaterials
            {
                public string name;
                public float count;
            }

            public List<RawMaterials> materials;
            public string name;
            public float productionTime;
        }
        
        public List<Resource> resources = new();
    }
}