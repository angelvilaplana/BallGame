using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxAnimation : MonoBehaviour
{
    public RawImage image;
    public float parallaxSpeed = 0.02f;

    public void Update()
    {
        float finalspeed = parallaxSpeed * Time.deltaTime;
        image.uvRect = new Rect(0, image.uvRect.y + finalspeed, 1f, 1f);
    }
}
