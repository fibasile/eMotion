using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{

    // Use this for initialization

    public Animator logoAnimation;
    public CanvasGroup background;

    public GameObject snakes;

    void Start()
    {
        Invoke("StartAnimation", 1);
        // logoAnimation.enabled = true;
        // logoAnimation.Play("FadeLogoIn");
    }
    public void StartAnimation()
    {

        logoAnimation.enabled = true;
        snakes.SetActive(true);
        Invoke("StopAnimation", 1.8f);
    }

    public void StopAnimation()
    {
        logoAnimation.enabled = false;

        // background.alpha = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
