using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float shootRate; // x in 1 second // second/fireRate

    private bool isCoActive = false;

    private void Start()
    {
        shootRate = 1.0f;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if (isCoActive)
            yield break;

        isCoActive = true;

        Instantiate(bullet, firePoint.position, firePoint.rotation);

        yield return new WaitForSeconds(1f/shootRate);
        isCoActive = false;
    }
}
