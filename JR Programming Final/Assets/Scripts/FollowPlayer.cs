using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float zCameraOffset;
    public GameManager gameManager;

    private void Start()
    {
        player = gameManager.player;
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + zCameraOffset);   
    }
}
