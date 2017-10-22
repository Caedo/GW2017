using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : MonoBehaviour {

    public float runSpeed = 6;
    public float timeToExplode = 5;
    public float maxDistanceFromPlayer = 1;

    private bool isExplosion = false;
    private float remainingTime = 0;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        remainingTime += Time.deltaTime;
        if(remainingTime > timeToExplode || isExplosion)
        {
            Explode();
        }
        else
        {
            transform.LookAt(FindTarget());
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
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

    }
}
