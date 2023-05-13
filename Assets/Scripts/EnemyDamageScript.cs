using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    public PlayerHealthScript playerHealth;
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
