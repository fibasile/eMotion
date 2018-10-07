using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        iTween.RotateTo(gameObject, iTween.Hash(
                      "x", 180.0f,
                      "y", 180.0f,
                      "z", 90.0f,
                      "time", 3f,
                      "easetype", "linear",
                      "looptype", iTween.LoopType.loop
                  ));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
