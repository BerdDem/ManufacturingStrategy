﻿using Source.View.Properties;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private LocationBuilder _locationBuilder;
        
        private readonly IntProperty _indexSelectedButton = new();

        private void Start()
        {
            SetSelectedButton(1);
        }

        public void SetSelectedButton(int buttonIndex)
        {
            _indexSelectedButton.value = buttonIndex;
        }

        public void StartGame()
        {
            _locationBuilder.AddResourceBuildingToPool(_indexSelectedButton.value);
            _locationBuilder.DropBuildings();

            gameObject.SetActive(false);
        }
    }
}