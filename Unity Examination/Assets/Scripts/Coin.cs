using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _prefabOneshot;
    [SerializeField] private AudioClip _sound;
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Oneshot oneshot = Instantiate(_prefabOneshot, transform.position, Quaternion.identity).GetComponent<Oneshot>();
            oneshot.Play(_sound);
            
            Destroy(gameObject);
        }
    }
}
