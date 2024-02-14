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
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            particles.Play();
            Debug.Log("finished level");
        }
    }
}
