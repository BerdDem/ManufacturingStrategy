using Source.Data.ScriptableObjects;
using UnityEngine;

namespace Source.Data
{
    public class GameData : MonoBehaviour
    {
        public ResourcesData resourcesData => _resourcesData;
        public ResourceForgeBuildingData resourceForgeBuildingData => _resourceForgeBuildingData;
        public ResourceConverterBuildingData resourceConverterBuildingData => _resourceConverterBuildingData;

        [SerializeField] private ResourcesData _resourcesData;
        [SerializeField] private ResourceForgeBuildingData _resourceForgeBuildingData;
        [SerializeField] private ResourceConverterBuildingData _resourceConverterBuildingData;
    }
}