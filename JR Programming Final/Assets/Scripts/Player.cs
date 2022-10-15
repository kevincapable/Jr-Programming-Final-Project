using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horInput;
    private float verInput;
    private bool jumpInput;
    private Vector3 moveInput;
    public float speed;
    public Vector3 playerPosition;
   
    Animator animator;
    
    public GameObject[] ammoArray;

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

        animator.SetFloat("Speed",Vector3.Magnitude(moveInput));
    }


    public void Move()
    {
        
        transform.Translate(moveInput*speed);
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Shoot()
    {
        
        Instantiate(ammoArray[0], transform.position + new Vector3(0,1,1) ,transform.rotation);
    }

    
}
