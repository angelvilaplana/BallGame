using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * (Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "DestroyEnemy")
        {
            Destroy(gameObject);
        }
    }
}
