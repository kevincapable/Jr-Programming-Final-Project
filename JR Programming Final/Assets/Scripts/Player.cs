using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected float horInput;
    protected float verInput;
    protected bool jumpInput;
    protected Vector3 moveInput;
    public float speed;
    public Vector3 playerPosition;
   
    protected Animator animator;
    
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


    public virtual void Move()
    {
        if (Mathf.Abs(transform.position.x) > 50)
        {
            transform.position = new Vector3(Mathf.Sign(transform.position.x)*50, transform.position.y, transform.position.z);
        }

        if (Mathf.Abs(transform.position.z) > 50)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sign(transform.position.z) * 50);
        }

        transform.Translate(moveInput*speed);
        Debug.Log(moveInput.ToString());
    }

    public virtual void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public virtual void Shoot()
    {
        
        Instantiate(ammoArray[0], transform.position + new Vector3(0,1,1) ,transform.rotation);
    }

    
}
