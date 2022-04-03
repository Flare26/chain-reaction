using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] float explosionForce;
    [SerializeField] float explosionRadius;
    ParticleSystem explosion;
    MeshCollider col;
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        explosion = GetComponent<ParticleSystem>();
        col = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision c)
    {
        Vector3 fcontact;
        fcontact = c.GetContact(0).point; // get first point of contact
        if (c.collider.tag == "Player")
        {
            // EXPLODE
            mesh.enabled = false;
            explosion.Play();
            c.collider.attachedRigidbody.AddExplosionForce(explosionForce, fcontact, explosionRadius, 2f, ForceMode.Impulse);
            col.enabled = false;
        }
    }

    public void Reset()
    {
        mesh.enabled = true;
    }
}
