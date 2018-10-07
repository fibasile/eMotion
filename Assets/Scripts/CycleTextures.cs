using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTextures : MonoBehaviour
{

    public Texture[] heads;
    Texture current = null;
    int TexIterator;
    Renderer m_Renderer;

    public float interval;

    string[] faces = {
        "KA.AN1.39",
        "KA.AN2.40",
        "KA.AN3.41",
        "KA.DI1.42",
        "KA.DI2.43",
        "KA.DI3.44",
        "KA.FE1.45",
        "KA.FE2.46",
        "KA.FE3.47",
        "KA.FE4.48",
        "KA.HA1.29",
        "KA.HA2.30",
        "KA.HA3.31",
        "KA.HA4.32",
        "KA.NE1.26",
        "KA.NE2.27",
        "KA.NE3.28",
        "KA.SA1.33",
        "KA.SA2.34",
        "KA.SA3.35",
        "KA.SU1.36",
        "KA.SU2.37",
        "KA.SU3.38",
        "KL.AN1.167",
        "KL.FE3.176",
        "KL.HA1.158",
        "KL.HA2.159",
        "KL.HA3.160",
        "KL.NE1.155",
        "KL.NE2.156",
        "KL.SA2.162",
        "KL.SA3.163",
        "KL.SU1.164",
        "KL.SU2.165",
        "KL.SU3.166",
        "KM.AN1.17",
        "KM.AN2.18",
        "KM.AN3.19",
        "KM.DI1.20",
        "KM.DI3.22",
        "KM.FE1.23",
        "KM.FE2.24",
        "KM.FE3.25",
        "KM.HA1.4",
        "KM.HA2.5",
        "KM.HA3.6",
        "KM.HA4.7",
        "KM.NE1.1",
        "KM.NE2.2",
        "KM.NE3.3",
        "KM.SA1.9",
        "KM.SA2.10",
        "KM.SA3.11",
        "KM.SA5.13",
        "KM.SU1.14",
        "KM.SU2.15",
        "KM.SU3.16",
        "KR.AN1.83",
        "KR.AN2.84",
        "KR.AN3.85",
        "KR.DI1.86",
        "KR.DI2.87",
        "KR.DI3.88",
        "KR.FE1.89",
        "KR.FE2.90",
        "KR.FE3.91",
        "KR.HA1.74",
        "KR.HA2.75",
        "KR.NE1.71",
        "KR.NE2.72",
        "KR.NE3.73",
        "KR.SA1.77",
        "KR.SA2.78",
        "KR.SA3.79",


        };

    // Use this for initialization
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        string facePath = faces[Mathf.RoundToInt(Random.Range(0.0f, (float)faces.Length - 1))];
        string texPath = "Faces/jaffe/" + facePath;
        // Debug.Log("Loading " + texPath);
        current = Resources.Load(texPath) as Texture;
        // Debug.Log(current);

        Invoke("updateTexture", interval);

    }


    public void updateTexture()
    {

        m_Renderer.material.SetTexture("_MainTex", current);
        string facePath = faces[Mathf.RoundToInt(Random.Range(0.0f, (float)faces.Length - 1))];
        current = Resources.Load("Faces/jaffe/" + facePath) as Texture;
        // Debug.Log(current);
        Invoke("updateTexture", interval);

    }


    // Update is called once per frame
    void Update()
    {

    }
}
