using Source.Data;
using Source.Data.ScriptableObjects;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIResourcePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _resourceObject;

        private void Start()
        {
            foreach (ResourcesData.Resource resourceData in DataManager.instance.gameData.resourcesData.resources)
            {
                GameObject resourceObject = Instantiate(_resourceObject, transform);
                UIResource uiResource = resourceObject.GetComponent<UIResource>();
                uiResource.SetResource(resourceData.name);
            }
        }
    }
}