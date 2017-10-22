using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : Item {

    bool m_IsPlaced;
    bool isUsed = false;

    public float runSpeed = 6;
    public float timeToExplode = 5;
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

    protected override void Awake()
    {
        base.Awake();
    }

    public override void PickUp()
    {
        base.PickUp();
    }

    public override void Use()
    {
        isUsed = true;
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

    void Update()
    {
        if(isUsed)
        {
            remainingTime += Time.deltaTime;
            if (remainingTime > timeToExplode || isExplosion)
            {
                if (!exploded)
                {
                    Explode();
                    remainingTime = timeToExplode - 2;
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
            else
            {
                transform.LookAt(FindTarget());
                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            }
        }

    }

    Transform FindTarget()
    {
        var targets = GameObject.FindGameObjectsWithTag("Player");

        float distance = Vector3.Distance(transform.position, targets[0].transform.position);
        float minDistance = distance;
        int index = 0;

        for (int i = 1; i < targets.Length; i++)
        {
            distance = Vector3.Distance(transform.position, targets[i].transform.position);
            if(distance < minDistance)
            {
                index = i;
                minDistance = distance;
            }
        }

        if(minDistance < maxDistanceFromPlayer)
        {
            isExplosion = true;
        }

        return targets[index].transform;
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
