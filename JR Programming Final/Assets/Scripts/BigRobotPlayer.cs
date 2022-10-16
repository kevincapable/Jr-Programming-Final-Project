using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRobotPlayer : Player
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        verInput = Input.GetAxis("Vertical") * Time.deltaTime;
        moveInput = new Vector3(horInput, 0, verInput);

        jumpInput = Input.GetKeyDown(KeyCode.Space);

        if (Mathf.Abs(horInput) > 0 || Mathf.Abs(verInput) > 0)
        {
            Move();
        }

        if (jumpInput)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        animator.SetFloat("Speed", Vector3.Magnitude(moveInput));
    }
}
