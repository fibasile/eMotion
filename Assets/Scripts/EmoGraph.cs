using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmoGraph : MonoBehaviour
{

    public TextMeshPro text;

    public Transform[] bars;

    public float[] values;

    // Use this     for initialization
    void Start()
    {
        values = new float[bars.Length];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(2.0f, 4.0f);
        }
        InvokeRepeating("UpdateBars", .3f, .3f);
    }
    public void ScaleAround(Transform target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.localPosition;
        Vector3 B = pivot;

        Vector3 C = A - B; // diff from object pivot to desired pivot/origin

        float RS = newScale.x / target.localScale.x; // relative scale factor

        // calc final position post-scale
        Vector3 FP = B + C * RS;

        // finally, actually perform the scale/translation
        target.localScale = newScale;
        target.localPosition = FP;
    }

    void UpdateBars()
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(2.0f, 5.0f);
            string label = "";
            if (values[i] < 2.5f)
            {
                label = "FEAR";
            }
            else if (values[i] < 3.5f)
            {
                label = "HAPPY";
            }
            else if (values[i] < 4.5f)
            {
                label = "DISGUST";
            }
            else
            {
                label = "NEUTRAL";
            }
            text.text = label;
            // bars[i].localScale = new Vector3(bars[i].localScale.x, values[i], bars[i].localScale.z);
            ScaleAround(bars[i], new Vector3(0, 1, 0), new Vector3(bars[i].localScale.x, values[i], bars[i].localScale.z));
            bars[i].localPosition = new Vector3(bars[i].localPosition.x, -1.5f + values[i] / 2.0f, bars[i].localPosition.z);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
