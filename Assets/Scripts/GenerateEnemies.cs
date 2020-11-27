using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generateEnemies());
    }

    private IEnumerator generateEnemies()
    {
        while (true)
        {
            Instantiate(enemy, new Vector3(0, 4.887581e-06f, 41.9f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
