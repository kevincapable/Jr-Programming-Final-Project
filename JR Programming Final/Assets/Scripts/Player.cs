using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected float horInput;
    protected float verInput;
    public float speed;
    public float shootTime;

    protected Vector3 moveInput;
    public Vector3 playerPosition;

    protected Animator animator;

    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        playerPosition = transform.position;
        shootTime = 0.0f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();

        }
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
        shootTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && (shootTime >= 0.1f))
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25));
            
            float meshX = Camera.main.transform.position.x //World space position of mouse clicked on the xz plane at y=0
                + (mousePoint.x - Camera.main.transform.position.x)
                * (Camera.main.transform.position.y-2)
                / (Camera.main.transform.position.y - mousePoint.y);
            float meshZ = Camera.main.transform.position.z
                + (mousePoint.z - Camera.main.transform.position.z)
                * (Camera.main.transform.position.y-2)
                / (Camera.main.transform.position.y - mousePoint.y);
           
            gameManager.ammoDirection = (new Vector3(meshX,0,meshZ) -  transform.position - new Vector3(0, 2, 1)).normalized;
            Instantiate(gameManager.ammoArray[gameManager.ammoIndex], transform.position + new Vector3(0, 2, 1), transform.rotation);
            shootTime = 0;

        }
            
    }

    
}
