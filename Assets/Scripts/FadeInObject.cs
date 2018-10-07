using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInObject : MonoBehaviour
{

    // Use this for initialization
    public float targetScale = 0.6f;
    public float targetAlpha = 0.6f;

    public float speed = 3.0f;

    public bool fade = false;
    void Start()
    {
        if (fade)
            iTween.FadeTo(gameObject, targetAlpha, speed);
        iTween.ScaleTo(gameObject, new Vector3(targetScale, targetScale, targetScale), speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
