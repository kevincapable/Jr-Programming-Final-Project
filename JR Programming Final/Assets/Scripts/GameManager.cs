using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] charArray;
    public Vector3 startPosition;
    public GameObject player;
    public GameObject[] ammoArray;
    public int ammoIndex = 0;
    public Vector3 ammoDirection;

    private void Awake()
    {
        Instantiate(charArray[MainManager.characterSelec], startPosition, Quaternion.Euler(0,0,0));

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        AmmoSwap();
    }

    public void AmmoSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ammoIndex = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ammoIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ammoIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ammoIndex = 3;
        }
    }
}
