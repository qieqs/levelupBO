using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class LevelEndPoint : MonoBehaviour
{
    [HideInInspector] public ParticleSystem particles;
    AudioSource audiosource; 
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();   
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            particles.Play();
            audiosource.Play();
            Debug.Log("finished level");
        }
    }
}
