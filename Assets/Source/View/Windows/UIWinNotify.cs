using Source.Data;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIWinNotify : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        
        private const string goldResourceName = "gold";
        
        private void Awake()
        {
            DataManager.instance.playerResourceContainer.SubscribeResourceChange(goldResourceName, ChangeGoldNotification);
            ChangeGoldNotification(DataManager.instance.playerResourceContainer.GetResourceValue(goldResourceName));
        }

        private void ChangeGoldNotification(float goldAmount)
        {
            if (goldAmount >= DataManager.instance.goldAmountToWin)
            {
                _root.SetActive(true);
            }
        }
    }
}