using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cow : MonoBehaviour
{
    public Collider col;
    public Rigidbody rb;
    public gameManager gm;
    public AudioSource audioSource;

    public LayerMask enviornment;

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
        if (collision.gameObject.layer != LayerMask.NameToLayer("Enviornment"))
        {
            Vector3 impulseLocation = collision.transform.position;
            rb.AddExplosionForce(1250, impulseLocation, 2);
            audioSource.clip = gm.playCowSound();
            audioSource.Play();
            print("MOO!");
            gm.score+=100;
        }

    }
}
