using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    AudioSource aS;

    void Start()
    {
        aS = GetComponent<AudioSource>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            aS.Play();
        }
        Destroy(gameObject);
    }
}
