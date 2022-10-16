using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected float horInput;
    protected float verInput;
    protected Vector3 moveInput;
    public float speed;
    public Vector3 playerPosition;
    protected Animator animator;
    public GameManager gameManager;

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

        Move(); //ABSTRACTION
        Jump();
        Shoot();
        CheckBound();

        animator.SetFloat("Speed",Vector3.Magnitude(moveInput));
    }

    public virtual void CheckBound()
    {
        if (Mathf.Abs(transform.position.x) > 50)
        {
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * 50, transform.position.y, transform.position.z);
        }

        if (Mathf.Abs(transform.position.z) > 50)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sign(transform.position.z) * 50);
        }

        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
    public virtual void Move()
    {
        if (Mathf.Abs(horInput) > 0 || Mathf.Abs(verInput) > 0)
        {
            transform.Translate(moveInput * speed);
        }

    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        
    }

    public virtual void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameManager.ammoDirection = new Vector3
                                                (
                                                    Camera.main.ScreenPointToRay(Input.mousePosition).direction.x,
                                                    0,
                                                    Camera.main.ScreenPointToRay(Input.mousePosition).direction.z
                                                ).normalized;

            Instantiate(gameManager.ammoArray[gameManager.ammoIndex], transform.position + new Vector3(0, 2, 1), transform.rotation);
            

        }
            
    }

    
}
