using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public enum Movements { LEFT_TO_RIGHT, RIGHT_TO_LEFT }

    public float speed = 2;
    public float xMargin = 5;
    public Movements movement;

    // Start is called before the first frame update
    void Start()
    {
        if (movement == Movements.LEFT_TO_RIGHT)
        {
            StartCoroutine(moveLeftToRight());
        }
        else
        {
            StartCoroutine(moveRightToLeft());
        }
    }

    private IEnumerator moveLeftToRight()
    {
        var toRight = true;
        while (true)
        {
            if (toRight)
            {
                if (transform.position.x > xMargin)
                {
                    toRight = false;
                }
                else
                {
                    transform.position += Vector3.right * (Time.deltaTime * speed);
                }
            } 
            else
            {
                if (transform.position.x < -xMargin)
                {
                    toRight = true;
                }
                else
                {
                    transform.position += Vector3.left * (Time.deltaTime * speed);
                }
            }

            yield return null;
        }
    }
    
    private IEnumerator moveRightToLeft()
    {
        var toLeft = true;
        while (true)
        {
            if (toLeft)
            {
                if (transform.position.x < -xMargin)
                {
                    toLeft = false;
                }
                else
                {
                    transform.position += Vector3.left * (Time.deltaTime * speed);
                }
            } 
            else
            {
                if (transform.position.x > xMargin)
                {
                    toLeft = true;
                }
                else
                {
                    transform.position += Vector3.right * (Time.deltaTime * speed);
                }
            }

            yield return null;
        }
    }
    
}
