using Source.Data;
using Source.View.Properties;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIGoldCount : MonoBehaviour
    {
        [SerializeField] private string _goldResourceName = "gold";

        private readonly IntProperty _goldCount = new();

        private void Start()
        {
            DataManager.instance.playerResourceContainer.SubscribeResourceChange(_goldResourceName, ChangeResourceNotification);
        }

        private void ChangeResourceNotification(float resourceValue)
        {
            _goldCount.value = (int)resourceValue;
        }
    }
}