using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] charArray;
    public Vector3 startPosition;
    public GameObject player;
    private void Awake()
    {
        Instantiate(charArray[MainManager.characterSelec], startPosition, Quaternion.Euler(0,0,0));

        player = GameObject.FindGameObjectWithTag("Player");
    }

}
