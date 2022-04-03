using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] float explosionForce;
    [SerializeField] float explosionRadius;
    [SerializeField] float upwardForce;
    ParticleSystem explosion;
    MeshCollider col;
    MeshRenderer mesh;
    BlastRadius br;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        explosion = GetComponent<ParticleSystem>();
        col = GetComponent<MeshCollider>();
        br = GetComponentInChildren<BlastRadius>();

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
                c.collider.attachedRigidbody.AddExplosionForce(explosionForce, fcontact, explosionRadius, upwardForce, ForceMode.Impulse);
                col.enabled = false;
            br.ApplyExplosionForce(fcontact, explosionRadius, 2f, upwardForce, ForceMode.Impulse);
        }
    }

    public void Reset()
    {
        mesh.enabled = true;
    }
}
