using System;
using System.Collections.Generic;
using Source.Buildings;
using Source.View.Windows;
using UnityEngine;

namespace Source
{
    public class LocationBuilder : MonoBehaviour
    {
        private readonly Vector2 XRange = new(-6, 6.1f);
        private readonly Vector2 YRange = new(0, -3.1f);
        
        [SerializeField] private GameObject _resourceBuilding;
        [SerializeField] private GameObject _converterBuilding;
        [SerializeField] private GameObject _marketBuilding;

        private readonly List<UIBuilding> _uiBuildings = new();

        private int _resourceBuildingAmount;
        private Vector2 _buildingPosition;

        private void Awake()
        {
            _buildingPosition = new Vector2(XRange.x, YRange.x);
        }

        public void SetResourceBuildingAmount(int resourceBuildingAmount)
        {
            _resourceBuildingAmount = resourceBuildingAmount;
        }

        public void DropBuildings()
        {
            for (int i = 0; i < _resourceBuildingAmount; i++)
            {
                GameObject resourceBuildingObject = Instantiate(_resourceBuilding, GetBuildingPosition(), Quaternion.identity, transform);
                resourceBuildingObject.GetComponent<ResourceBuilding>().Initialize(new ResourceForge());
                UIResourceForgeBuilding uiForgeBuilding = resourceBuildingObject.GetComponent<UIResourceForgeBuilding>();
                
                uiForgeBuilding.showEvent += ShowBuildingWindow;
                _uiBuildings.Add(uiForgeBuilding);
            }
            
            GameObject _converterBuildingObject = Instantiate(_converterBuilding, GetBuildingPosition(), Quaternion.identity, transform);
            _converterBuildingObject.GetComponent<ResourceBuilding>().Initialize(new ResourceConverter());
            UIResourceConverterBuilding uiConverterBuilding = _converterBuildingObject.GetComponent<UIResourceConverterBuilding>();

            uiConverterBuilding.showEvent += ShowBuildingWindow;
            _uiBuildings.Add(uiConverterBuilding);
            
            GameObject _marketBuildingObject = Instantiate(_marketBuilding, GetBuildingPosition(), Quaternion.identity, transform);
            UIMarketBuilding uiMarketBuilding = _marketBuildingObject.GetComponent<UIMarketBuilding>();

            uiMarketBuilding.showEvent += ShowBuildingWindow;
            _uiBuildings.Add(uiMarketBuilding);
        }

        private Vector2 GetBuildingPosition()
        {
            if (_buildingPosition.x >= XRange.y)
            {
                _buildingPosition.x = XRange.x;
                _buildingPosition += new Vector2(0, -3);
            }

            Vector2 value = _buildingPosition;
            _buildingPosition += new Vector2(6, 0);

            return value;
        }
        
        private void ShowBuildingWindow(UIBuilding uiBuilding)
        {
            foreach (UIBuilding building in _uiBuildings)
            {
                if (building == uiBuilding)
                {
                    continue;
                }
                
                building.Hide();
            }
        }
    }
}