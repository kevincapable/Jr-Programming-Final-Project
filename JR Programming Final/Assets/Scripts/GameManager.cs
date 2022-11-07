using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 ammoDirection;

    public GameObject[] charArray;
    public GameObject player;
    public GameObject[] ammoArray;
    public GameObject[] enemyArray;
    public GameObject gameOverCanvas;

    public int ammoIndex = 0;
    public int waveNumber;
    public int enemyHP;
    public int enemiesLeft;
    
    public bool gameOver;

    public float enemySpeed;
    public float gameTime;



    private void Awake()
    {
        Instantiate(charArray[MainManager.characterSelec], startPosition, Quaternion.Euler(0,0,0));

        player = GameObject.FindGameObjectWithTag("Player");

        gameTime = 0;
        gameOver = false;
        
        enemySpeed = 1;
        enemyHP = 0;

        waveNumber = 0;
        enemiesLeft = 0;
    }

    private void Update()
    {
        AmmoSwap();

        if (enemiesLeft <= 0)
        {
            NewWave();
        }
    }

    public void NewWave()
    {
        waveNumber++;
        enemyHP++;
        enemySpeed *= 1.1f;

        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyArray[1], //Spawn French Fries
                        new Vector3(Random.Range(-50, 50), 2.0f, 50), 
                        Quaternion.Euler(Vector3.back));
            Instantiate(enemyArray[0], //Spawn burgers
                        new Vector3(Random.Range(-50, 50), 5, 50), 
                        Quaternion.Euler(Vector3.back));
            enemiesLeft += 2;
        }
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

    public void GameOver()
    {
        gameOver = true;
        gameOverCanvas.SetActive(true);
    }

    public void GameReset()
    {
        SceneManager.LoadScene(1);
    }


}
