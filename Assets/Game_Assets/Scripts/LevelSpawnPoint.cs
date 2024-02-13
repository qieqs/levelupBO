using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnPoint : MonoBehaviour
{
    PlayerLifeSupport playerlife;
    [HideInInspector] public ParticleSystem particles;
    void Start()
    {
        playerlife = FindObjectOfType<PlayerLifeSupport>();
        particles = GetComponentInChildren<ParticleSystem>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerlife.currspawnpoint = this.transform.position + new Vector3(0, 2,0);
            if (particles)
            {
                particles.Play();
            }
            Debug.Log("checkpoint is gezet");
        }
    }
}
