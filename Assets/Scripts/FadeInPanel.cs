using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInPanel : MonoBehaviour
{
    // private Vector3 originalScale;
    // Use this for initialization
    void Start()
    {
        // Transform transform = GetComponent<Transform>();
        // originalScale = transform.localScale;
        // transform.localScale = new Vector3(0.0f, originalScale.y, 0.0f);
        iTween.FadeTo(gameObject, 0.0f, 0.0f);

    }

    public void Appear()
    {
        iTween.FadeTo(gameObject, 0.5f, .3f);
        // iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(originalScale.x, originalScale.y, originalScale.z * 0.01f), "time", 0.7f, "oncomplete", "fade1Complete"));
    }

    // public void fade1Complete()
    // {
    //     iTween.ScaleTo(gameObject, originalScale, 0.8f);
    //     iTween.FadeTo(gameObject, 1.0f, .8f);
    // }

    public void Disappear()
    {
        iTween.FadeTo(gameObject, 0.0f, 0.3f);
        // iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(originalScale.x, originalScale.y, originalScale.z * 0.01f), "time", 0.6f, "oncomplete", "fade2Complete"));
    }

    // public void fade2Complete()
    // {
    //     iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0.0f, originalScale.y, originalScale.z * 0.01f), "time", 0.3f));
    //     iTween.FadeTo(gameObject, 0.0f, 0.3f);
    // }

    // Update is called once per frame
    // void Update()
    // {


    // }
}
