using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    private float verticalMove;
    private float horizontalMove;

    private Animator animator;

    private Camera cam;
    private Vector3 worldPos;
    private float angleRad;
    private float angleDeg;

    void Start()
    {
        moveSpeed = 5.0f + (PlayerPrefs.GetInt("movementSpeed", 0)*2);
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Ship rotation to mouse cursor
        worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        angleRad = Mathf.Atan2(worldPos.y - this.transform.position.y, worldPos.x - this.transform.position.x);
        angleDeg = (180 / Mathf.PI) * angleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, angleDeg + 270);

        //horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //verticalMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * -1;

        //transform.Translate(verticalMove, horizontalMove, 0);

        MovementAndAnimation();
    }

    void MovementAndAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            animator.SetBool("isLeftTurn", true);
        }
        else
        {
            animator.SetBool("isLeftTurn", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
            animator.SetBool("isRightTurn", true);
        }
        else
        {
            animator.SetBool("isRightTurn", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
