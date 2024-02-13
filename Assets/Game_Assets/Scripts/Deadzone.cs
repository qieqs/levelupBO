using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Deadzone : MonoBehaviour
{
    public Vector3 spawnpointpos;
    public PlayerLifeSupport playerlife;
    private bool spawnpointavailable;

    private void Start()
    {
        playerlife = FindObjectOfType<PlayerLifeSupport>();
    }

    private bool CheckForSpawnPoints()
    {
        bool checker = false;
        if (playerlife.spawnpoints.Length == 0)
            checker = false;
        else
            checker = true;
        return checker;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("je bent dood");
            other.GetComponent<CharacterController>().enabled = false;
            if (CheckForSpawnPoints())
            {
                other.transform.position = playerlife.currspawnpoint;
            }
            else
            {
                other.transform.position = spawnpointpos + new Vector3(0, 2, 0);
            }
            other.GetComponent<CharacterController>().enabled = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(spawnpointpos, 1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spawnpointpos, 1.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);

        //GUIStyle style = new GUIStyle();
        //style.normal.textColor = Color.green;
        //Handles.Label(spawnpointpos + new Vector3(0, 1.5f, 0), "Spawn Punt", style);
    }
}
