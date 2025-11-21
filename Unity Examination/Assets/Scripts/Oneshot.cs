using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] public class Oneshot : MonoBehaviour
{
    private AudioSource _source;
    
    
    
    public void Play(AudioClip clip)
    {
        _source = GetComponent<AudioSource>();
        
        _source.clip = clip;
        _source.Play();
    }

    private void Update()
    {
        if (_source != null && !_source.isPlaying)
            Destroy(gameObject);
    }
}
