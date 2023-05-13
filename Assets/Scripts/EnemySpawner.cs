using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skeletonPrefab;

    [SerializeField]
    private float skeletonInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(skeletonInterval, skeletonPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-7f, 7f), Random.Range(-7f, 7f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
