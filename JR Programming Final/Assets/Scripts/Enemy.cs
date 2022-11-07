using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject targetPlayer;
    
    public Slider hpSlider;
    
    public TMP_Text hpText;
    
    public float speed;

    public int healthPoints;
    public int maxHealthPoints;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        speed = gameManager.enemySpeed;
        maxHealthPoints = gameManager.enemyHP*2;
        healthPoints = maxHealthPoints;
        targetPlayer = gameManager.player;
        hpText.text = "HP: " + healthPoints;
    }
    
    // Update is called once per frame
    void Update()
    {
        hpSlider.value = (healthPoints - healthPoints) / healthPoints;
        MoveToPlayer();
    }

    public virtual void MoveToPlayer()
    {
        transform.Translate
    (
        speed * Time.deltaTime *
        Vector3.Normalize
        (
            new Vector3
                (
                    targetPlayer.transform.position.x - transform.position.x,
                    0,
                    targetPlayer.transform.position.z - transform.position.z
                )
        )
    );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            healthPoints -= 1;
            hpText.text = "HP: " + healthPoints;
            hpSlider.value = (maxHealthPoints - healthPoints) / maxHealthPoints;
        }

        if (healthPoints < 1)
        {
            Destroy(gameObject);
            gameManager.enemiesLeft--;
        }
    }
}
