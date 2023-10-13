using Source.Buildings;
using UnityEngine;

namespace Source.View.Windows
{
    public class UIResourceForgeBuilding : MonoBehaviour
    {
        [SerializeField] private ResourceBuilding _resourceBuilding;

        private bool _buildEnable;
        
        public void ChangeResource(string resourceName)
        {
            _resourceBuilding.SelectResource(resourceName);
        }

        public void BuildEnable()
        {
            _buildEnable = !_buildEnable;
        }
    }
}