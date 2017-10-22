using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    bool m_IsPlaced;
    bool isUsed = false;
    public float timeToExplode = 1;
    public float maxDistanceFromPlayer = 1;
    public ParticleSystem explosion;
    public float explosionRadius = 5.0f;
    public float explosionPower = 500.0f;

    private ParticleSystem expl;
    private bool exploded = false;
    private bool isExplosion = false;
    private float remainingTime = 0;

    public override bool CanBePicked
    {
        get
        {
            return !m_IsPlaced;
        }

        set
        {
            base.CanBePicked = value;
        }
    }

    public override void Throw(Vector3 direction, float force)
    {
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = true;

        transform.parent = null;

        rigidbody.AddForce(direction * force, ForceMode.Impulse);
        isUsed = true;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Use()
    {
        isUsed = true;
    }

    public override void PickUp()
    {
        base.PickUp();
    }

    void Update()
    {
        if (isUsed)
        {
            remainingTime += Time.deltaTime;
            if (remainingTime > timeToExplode || isExplosion)
            {
                if (!exploded)
                {
                    Explode();
                    remainingTime = 3;
                    exploded = true;
                    MeshRenderer mr = gameObject.GetComponentInChildren<MeshRenderer>();
                    mr.enabled = false;
                }
                else
                {
                    expl.Stop();
                    Destroy(gameObject);
                }
            }
        }

    }

    void Explode()
    {
        expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Player"))
            {
                Rigidbody rb = hitColliders[i].GetComponentInParent<Rigidbody>();
                rb.AddExplosionForce(explosionPower, transform.position, explosionRadius);
            }
        }

        exploded = true;
    }
}
