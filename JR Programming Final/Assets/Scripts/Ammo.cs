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


}
