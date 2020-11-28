using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{

    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rotateEnemy());
    }

    private IEnumerator rotateEnemy()
    {
        while (true)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
            yield return null;
        }
    }
}
