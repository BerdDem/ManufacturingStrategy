using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source.View.Windows
{
    public class UIBuilding : MonoBehaviour
    {
        public Action<UIBuilding> showEvent;
        
        [SerializeField] private GameObject _canvas;
        [SerializeField] private Button _exitButton;

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);
        }

        private void OnMouseDown()
        {
            Show();
        }

        public virtual void Show()
        {
            _canvas.SetActive(true);
            showEvent?.Invoke(this);
        }

        public virtual void Hide()
        {
            _canvas.SetActive(false);
        }
    }
}