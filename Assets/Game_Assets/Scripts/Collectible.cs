using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    private AudioSource audiosource;

    private float xas;
    private float yas;
    private float zas;
    public float speed;
    public bool xaxis;
    public bool yaxis;
    public bool zaxis;

    public float amplitude = 0.2f;
    public float frequency = 0f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public GameObject particlesobject;
    private bool particlesActive;

    void Start()
    {
        audiosource = GetComponentInChildren<AudioSource>();  
        if (particlesobject == null)
        {
            Debug.LogError("er zijn geen verdwijnparticles toegevoegd aan dit object");
            particlesActive = false;
        }
        else
        {
            particlesActive = true;
            particlesobject.SetActive(false);
        }

        posOffset = transform.position;
    }


    void FixedUpdate()
    {
        if (xaxis)
            xas = 1;
        else
            xas = 0;

        if (yaxis)
            yas = 1;
        else
            yas = 0;

        if (zaxis)
            zas = 1;
        else
            zas = 0;



        transform.Rotate(new Vector3(xas, yas, zas) * speed * Time.deltaTime);
        floating();
    }

    private void floating()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(particlesActive)
            {
                particlesobject.transform.SetParent(null);
                particlesobject.SetActive(true);
                audiosource.Play();
            }
            Destroy(this.gameObject);
        }
    }


}
