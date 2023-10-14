using System.Collections.Generic;
using Source.Data.ScriptableObjects;
using UnityEngine;

namespace Source.Data
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                
                GameObject singletonObject = Instantiate(new GameObject());
                _instance = singletonObject.AddComponent<DataManager>();
                
                return _instance;
            }
        }
        
        public ResourceContainer playerResourceContainer { get; private set; }
        public GameData gameData => _gameData;

        [SerializeField] private GameData _gameData;
        
        private static DataManager _instance;   
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }

            playerResourceContainer = new ResourceContainer();


            
            //loadFromSave
            Dictionary<string, float> resource = new();
            foreach (ResourcesData.Resource resourceData in gameData.resourcesData.resources)
            {
                resource.Add(resourceData.name, 0);
            }
            playerResourceContainer.InitializeResources(resource);
        }
    }
}