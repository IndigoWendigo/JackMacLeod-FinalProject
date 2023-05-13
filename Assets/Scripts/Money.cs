using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreTextScript.instance.IncreaseScore(value);
        }
    }
}
