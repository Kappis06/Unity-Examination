using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    
    
    private void Awake()
    {
        #region SINGLETON
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
    }
}
