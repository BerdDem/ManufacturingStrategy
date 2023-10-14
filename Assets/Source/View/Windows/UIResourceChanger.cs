using System;
using System.Collections.Generic;
using Source.Data;
using Source.View.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Source.View.Windows
{
    public class UIResourceChanger : MonoBehaviour
    {
        public Action<string> resourceChangeEvent;
        
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;

        private readonly SpriteProperty _resourceSprite = new();
        
        private List<string> _resourceNames = new();
        private int _currentResourceIndex;
        private string _currentResource;

        private void Awake()
        {
            _previousButton.onClick.AddListener(PreviousButtonClick);
            _nextButton.onClick.AddListener(NextButtonClick);
        }

        public void SetResources(List<string> resourceNames)
        {
            _resourceNames = resourceNames;
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(_currentResource))
            {
                resourceChangeEvent?.Invoke(_resourceNames[0]);
                _resourceSprite.value = DataManager.instance.gameData.resourcesData.GetResource(_resourceNames[0]).sprite;
            }
        }

        private void PreviousButtonClick()
        {
            CycleInt(-1);
            
            _currentResource = _resourceNames[_currentResourceIndex];
            resourceChangeEvent?.Invoke(_currentResource);
            
            _resourceSprite.value = DataManager.instance.gameData.resourcesData.GetResource(_resourceNames[_currentResourceIndex]).sprite;
        }

        private void NextButtonClick()
        {
            CycleInt(1);
            
            _currentResource = _resourceNames[_currentResourceIndex];
            resourceChangeEvent?.Invoke(_currentResource);

            _resourceSprite.value = DataManager.instance.gameData.resourcesData.GetResource(_resourceNames[_currentResourceIndex]).sprite;
        }

        private void CycleInt(int increment)
        {
            _currentResourceIndex = (_currentResourceIndex + increment) % _resourceNames.Count;
            
            if (_currentResourceIndex < 0)
            {
                _currentResourceIndex += _resourceNames.Count;
            }
        }
    }
}