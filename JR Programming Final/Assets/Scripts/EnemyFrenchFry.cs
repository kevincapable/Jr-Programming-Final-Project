using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrenchFry : Enemy
{
    public float strafeSpeed;
    public int strafeIndex;
    public float strafeTime;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = gameManager.enemySpeed*2;
        maxHealthPoints = gameManager.enemyHP;
        healthPoints = gameManager.enemyHP;
        targetPlayer = gameManager.player;
        hpText.text = "HP: " + healthPoints;
        strafeSpeed = 10.0f;
        strafeIndex = 1;
        strafeTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = (healthPoints - healthPoints) / healthPoints;
        MoveToPlayer();
        strafeTime += Time.deltaTime;
        if (strafeTime >= 1)
        {
            strafeIndex *= -1;
            strafeTime = 0;
        }

    }


    public override void MoveToPlayer() //POLYMORPHISM
    {
        base.MoveToPlayer();
        transform.Translate(strafeSpeed*strafeIndex*Time.deltaTime, 0, 0);
    }
}
