using UnityEngine;

namespace Source
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                
                GameObject singletonObject = Instantiate(new GameObject());
                _instance = singletonObject.AddComponent<GameManager>();
                
                return _instance;
            }
        }
        
        public ResourceContainer playerResourceContainer { get; private set; }
        
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
        }
    }
}