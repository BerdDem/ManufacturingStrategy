using System;
using System.Collections.Generic;
using System.IO;
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
        public float goldAmountToWin => _goldAmountToWin;
        public bool firstStart { get; private set; }

        [SerializeField] private float _goldAmountToWin;
        [SerializeField] private GameData _gameData;
        [SerializeField] private float _timeToSave = 1;
        [SerializeField] private bool _removeData;
        
        private static DataManager _instance;
        private float _saveTimer;
        
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

            if (_removeData)
            {
                File.Delete(Application.persistentDataPath + ".json");
            }

            if (!LoadData(out Dictionary<string, float> resource))
            {
                foreach (ResourcesData.Resource resourceData in gameData.resourcesData.resources)
                {
                    resource.Add(resourceData.name, 0);
                }

                firstStart = true;
            }
            
            playerResourceContainer.InitializeResources(resource);
        }

        private void Update()
        {
            _saveTimer += Time.deltaTime;
            
            if (_saveTimer < _timeToSave)
            {
                return;
            }

            _saveTimer = 0;
            SaveData();
        }

        [Serializable]
        public class SerializableKeyValuePair
        {
            public string key;
            public float value;
        }

        [Serializable]
        public class SerializableDictionary
        {
            public List<SerializableKeyValuePair> dictionaryItems;
        }

        private void SaveData()
        {
            SerializableDictionary serializableDictionary = new()
            {
                dictionaryItems = new List<SerializableKeyValuePair>()
            };

            foreach (KeyValuePair<string, float> kvp in playerResourceContainer.resources)
            {
                SerializableKeyValuePair item = new()
                {
                    key = kvp.Key,
                    value = kvp.Value
                };
                serializableDictionary.dictionaryItems.Add(item);
            }

            string json = JsonUtility.ToJson(serializableDictionary);
            
            
            File.WriteAllText(Application.persistentDataPath + ".json", json);
        }
        
        private bool LoadData(out Dictionary<string, float> data)
        {
            data = new();
            
            string filePath = Application.persistentDataPath + ".json";

            if (!File.Exists(filePath))
            {
                return false;
            }
            
            string json = File.ReadAllText(filePath);
            SerializableDictionary serializableDictionary = JsonUtility.FromJson<SerializableDictionary>(json);

            foreach (SerializableKeyValuePair item in serializableDictionary.dictionaryItems)
            {
                data.Add(item.key, item.value);
            }
            
            return true;
        }
    }
}