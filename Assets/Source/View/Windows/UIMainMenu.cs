using Source.Data;
using Source.View.Properties;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private LocationBuilder _locationBuilder;
        [SerializeField] private GameObject _locationCanvasObject;
        
        private readonly IntProperty _indexSelectedButton = new();

        private void Start()
        {
            SetSelectedButton(1);
            if (!DataManager.instance.firstStart)
            {
                StartGame();
            }
        }

        public void SetSelectedButton(int buttonIndex)
        {
            _indexSelectedButton.value = buttonIndex;
        }

        public void StartGame()
        {
            _locationBuilder.SetResourceBuildingAmount(_indexSelectedButton.value);
            _locationBuilder.DropBuildings();

            gameObject.SetActive(false);
            _locationCanvasObject.gameObject.SetActive(true);
        }
    }
}