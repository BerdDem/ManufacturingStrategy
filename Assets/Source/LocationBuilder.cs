using System.Collections.Generic;
using Source.Buildings;
using UnityEngine;

namespace Source
{
    public class LocationBuilder : MonoBehaviour
    {
        private readonly Vector2 XRange = new(-6, 6.1f);
        private readonly Vector2 YRange = new(0, -3.1f);
        
        [SerializeField] private GameObject _resourceBuilding;
        [SerializeField] private GameObject _processingBuilding;
        [SerializeField] private GameObject _marketBuilding;

        private readonly List<GameObject> _buildings = new();

        private void Start()
        {
            _buildings.Add(_processingBuilding);
            _buildings.Add(_marketBuilding);
        }

        public void AddResourceBuildingToPool(int resourceBuildingCount)
        {
            for (int i = 0; i < resourceBuildingCount; i++)
            {
                _buildings.Add(_resourceBuilding);
            }
        }

        public void DropBuildings()
        {
            Vector2 buildingPosition = new(XRange.x, YRange.x);
            
            foreach (GameObject buildingPrefab in _buildings)
            {
                if (buildingPosition.x >= XRange.y)
                {
                    buildingPosition.x = XRange.x;
                    buildingPosition += new Vector2(0, -3);
                }
                
                GameObject buildingObject = Instantiate(buildingPrefab, buildingPosition, Quaternion.identity, transform);
                buildingObject.GetComponent<ResourceBuilding>().Initialize(new ResourceForge());

                buildingPosition += new Vector2(6, 0);
            }
        }
    }
}