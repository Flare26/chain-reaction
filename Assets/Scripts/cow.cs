using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cow : MonoBehaviour
{
    public Collider col;
    public Rigidbody rb;
    public gameManager gm;
    public AudioSource audioSource;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 impulseLocation = collision.transform.position;
        rb.AddExplosionForce(2500, impulseLocation, 2);
        audioSource.clip = gm.playCowSound();
        audioSource.Play();
    }
}
