using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _prefabOneshot;
    [SerializeField] private AudioClip _sound;

    [SerializeField] private UnityEvent _onPickUp;
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Oneshot oneshot = Instantiate(_prefabOneshot, transform.position, Quaternion.identity).GetComponent<Oneshot>();
            oneshot.Play(_sound);

            GameManager.Instance.UpdateCoinCounter();
            
            _onPickUp.Invoke();
            
            Destroy(gameObject);
        }
    }
}
