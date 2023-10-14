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
            public float productionTime;
        }
        
        public List<Resource> resources = new();
    }
}