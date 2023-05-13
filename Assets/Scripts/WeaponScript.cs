using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    AudioSource aS;

    public GameObject bullet;

    public Transform firePoint;

    public float fireForce;

    public void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        aS.Play();
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
