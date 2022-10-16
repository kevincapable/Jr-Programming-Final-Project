using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Rigidbody ammoBody;
    public float speed;

    private void Start()
    {
        speed = 25;
        ammoBody = GetComponent<Rigidbody>();
        ammoBody.velocity = Vector3.forward*speed;
    }

    private void Update()
    {
        if ((ammoBody.velocity.sqrMagnitude < 1) || (Mathf.Abs(transform.position.x) > 50) || (Mathf.Abs(transform.position.z) > 50))
        {
            Destroy(gameObject);
        }
    }
}
