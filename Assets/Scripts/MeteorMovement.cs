using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    public float meteorMinSpeed = -2.0f;
    public float meteorMaxSpeed = -10.0f;
    private float meteorSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        meteorSpeed = Random.Range(meteorMinSpeed, meteorMaxSpeed);
        //Debug.Log(meteorSpeed);
        //transform.position = transform.position + new Vector3(meteorSpeed*-1*Time.deltaTime, 0, 0);
        //transform.Translate(-1*Time.deltaTime,0,0);
        rb.velocity = new Vector2(meteorSpeed, 0);
    }
}
