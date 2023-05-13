using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    [Header ("Health")]
    public int maxHealth = 5;
    public int currentHealth;

    public SpriteRenderer playerSr;
    public PlayerController playerCr;

    [Header("IFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int iFrameFlashes;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth > 0)
        {
            StartCoroutine(Invulnerability());
        }

        if(currentHealth <= 0)
        {
            playerSr.enabled = false;
            playerCr.enabled = false;
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for(int i = 0; i <iFrameFlashes; i++)
        {
            playerSr.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1);
            playerSr.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    public string sceneName;

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}
