using System;
using Source.View.Properties;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIMainMenu : MonoBehaviour
    {
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
            
        }
    }
}