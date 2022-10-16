using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    private GameObject targetPlayer;
    public float speed;
    public Slider hpSlider;
    public TMP_Text hpText;
    public int healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 100000000;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetPlayer = gameManager.player;

        hpText.text = "HP: " + healthPoints;
    }
    
    // Update is called once per frame
    void Update()
    {
        hpSlider.value = (100000000 - healthPoints) / 100000000f;
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
            hpSlider.value = (100000000 - healthPoints) / 100000000f;
        }
    }
}
