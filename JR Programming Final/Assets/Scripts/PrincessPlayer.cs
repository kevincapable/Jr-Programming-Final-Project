using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessPlayer : Player //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        playerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        verInput = Input.GetAxis("Vertical") * Time.deltaTime;
        moveInput = new Vector3(horInput, 0, verInput);

        Move();
        Jump();
        Shoot();
        CheckBound();

        animator.SetFloat("Speed", Vector3.Magnitude(moveInput));
    }
}
