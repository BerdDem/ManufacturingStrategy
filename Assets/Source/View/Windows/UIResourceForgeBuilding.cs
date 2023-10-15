using System.Collections.Generic;
using Source.Buildings;
using Source.Data;
using Source.Data.ScriptableObjects;
using Source.View.Properties;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Source.View.Windows
{
    public class UIResourceForgeBuilding : UIBuilding
    {
        [SerializeField] private ResourceBuilding _resourceBuilding;
        [FormerlySerializedAs("_resourceChanger")] [SerializeField] private UIResourceSelector resourceSelector;
        [SerializeField] private Button _enableToggleButton;
        
        private readonly BoolProperty _buildingEnable = new();
        
        private void Start()
        {
            List<string> resources = new();
            foreach (ResourceForgeBuildingData.Resource resource in DataManager.instance.gameData.resourceForgeBuildingData.resources)
            {
                resources.Add(resource.name);
            }
            
            resourceSelector.resourceChangeEvent += ChangeResource;
            resourceSelector.SetResources(resources);
            
            _enableToggleButton.onClick.AddListener(BuildEnableToggle);
        }

        private void ChangeResource(string resourceName)
        {
            _resourceBuilding.SelectResource(resourceName);
            _buildingEnable.value = false;
            _resourceBuilding.BuildEnable(_buildingEnable.value);
        }

        private void BuildEnableToggle()
        {
            _buildingEnable.value = !_buildingEnable.value;
            
            _resourceBuilding.BuildEnable(_buildingEnable.value);
        }
    }
}