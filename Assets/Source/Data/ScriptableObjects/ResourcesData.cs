using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ResourcesData")]
    public class ResourcesData : ScriptableObject
    {
        [Serializable]
        public struct Resource
        {
            public string name;
            [FormerlySerializedAs("picture")] public Sprite sprite;
        }

        public List<Resource> resources = new();

        public Resource GetResource(string resourceName)
        {
            foreach (Resource resource in resources)
            {
                if (resourceName != resource.name)
                {
                    continue;
                }

                return resource;
            }

            throw new ArgumentException($"{resourceName} - not found");
        }
    }
}