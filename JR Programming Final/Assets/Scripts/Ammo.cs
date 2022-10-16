using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Rigidbody ammoBody;
    public float speed;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = 25;
        ammoBody = GetComponent<Rigidbody>();
        ammoBody.velocity = gameManager.ammoDirection*speed;
    }


    private void Update()
    {
        if ((ammoBody.velocity.sqrMagnitude < 1) || (Mathf.Abs(transform.position.x) > 50) || (Mathf.Abs(transform.position.z) > 50))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        
        
    }
}
