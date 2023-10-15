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
    public class UIResourceConverterBuilding : UIBuilding
    {
        [SerializeField] private ResourceBuilding _resourceBuilding;
        [FormerlySerializedAs("_resourceChanger")] [SerializeField] private UIResourceSelector resourceSelector;
        [SerializeField] private Button _enableToggleButton;
        
        private readonly BoolProperty _buildingEnable = new();
        private readonly SpriteProperty _firstsMaterialSprite = new();
        private readonly SpriteProperty _secondMaterialSprite = new();

        private List<ResourceConverterBuildingData.Resource.RawMaterials> _materials;
        private string _resourceName;
        
        private void Start()
        {
            resourceSelector.resourceChangeEvent += ResourceChange;
            _enableToggleButton.onClick.AddListener(BuildEnableToggle);

            List<string> resources = new();
            foreach (ResourceConverterBuildingData.Resource resource in DataManager.instance.gameData.resourceConverterBuildingData.resources)
            {
                resources.Add(resource.name);
            }
            resourceSelector.SetResources(resources);
        }

        private void ResourceChange(string resourceName)
        {
            GameData gameData = DataManager.instance.gameData;
            _materials = gameData.resourceConverterBuildingData.GetResource(resourceName).materials;
            
            _buildingEnable.value = false;
            _resourceBuilding.BuildEnable(_buildingEnable.value);
            _resourceBuilding.SelectResource(resourceName);

            _firstsMaterialSprite.value = gameData.resourcesData.GetResource(_materials[0].name).sprite;
            _secondMaterialSprite.value = gameData.resourcesData.GetResource(_materials[1].name).sprite;
        }

        private void BuildEnableToggle()
        {
            _buildingEnable.value = !_buildingEnable.value;
            
            _resourceBuilding.BuildEnable(_buildingEnable.value);
        }
    }
}