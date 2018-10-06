using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{

    // Use this for initialization

    public Animator logoAnimation;
    public CanvasGroup logo;

    public GameObject snakes;


    public CanvasGroup button;

    bool pulsate = false;
    void Start()
    {
        Invoke("StartAnimation", 1);
        // logoAnimation.enabled = true;
        // logoAnimation.Play("FadeLogoIn");
    }

    public void HandleStart()
    {
        Debug.Log("Start now");
        StartCoroutine("FadeOutUI");

    }

    IEnumerator FadeInButton()
    {
        float time = 1f;
        while (button.alpha < 1)
        {
            button.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

    IEnumerator FadeOutUI()
    {
        pulsate = false;
        float time = 1f;
        while (button.alpha > 0)
        {
            button.alpha -= Time.deltaTime / time;
            logo.alpha -= Time.deltaTime / time;
            snakes.SetActive(false);
            yield return null;
        }
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
        pulsate = true;
        StartCoroutine("FadeInButton");
        // background.alpha = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (pulsate)
        {
            logo.alpha = Mathf.Sin(Time.realtimeSinceStartup) + 1.7f;
        }

    }
}
