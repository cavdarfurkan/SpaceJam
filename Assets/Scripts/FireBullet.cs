using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;

    private Rigidbody2D rb;

    private Vector2 cursorPos;
    private Vector2 worldPos;
    private Camera cam;

    void Start()
    {
        bulletSpeed = 10.0f;
        bulletDamage = 1;

        rb = GetComponent<Rigidbody2D>();

        cam = Camera.main;
        cursorPos = Input.mousePosition;
        worldPos = cam.ScreenToWorldPoint(cursorPos) - transform.position;
        worldPos.Normalize();

        //Debug.Log(cursorPos);
        //Debug.Log(worldPos);

        Fire(worldPos);
    }

    void Fire(Vector2 cursorPos)
    {
        rb.velocity = cursorPos * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Meteor meteor = hitInfo.GetComponent<Meteor>();

        if(meteor != null)
        {
            meteor.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
