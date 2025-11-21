using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;



    private TMP_Text _coinCounter;
    private int _coinsCollected = 0;
    
    
    
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



        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject coinCounter = GameObject.FindGameObjectWithTag("Coin Counter");
        if (coinCounter != null)
            _coinCounter = coinCounter.GetComponent<TextMeshProUGUI>();
    }



    public void UpdateCoinCounter()
    {
        _coinsCollected++;
        _coinCounter.text = $"COINS: {_coinsCollected}";
    }
}
