using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public static int BottomLeft = 0;
    public static int BottomRight = 1;

    public static int TopRight = 2;
    public static int TopLeft = 3;

    public static int SideLeft = 4;

    public static int SideRirght = 5;


    public Vector4[] positions = new Vector4[6];

    public GameObject panelPrefab;

    public GameObject[] panels = new GameObject[6];


    // Use this for initialization
    void Start()
    {

        // Vector3 oldPosition = gameObject.transform.position;
        // gameObject.transform.position = Vector3.zero;

        // Quaternion quat = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        // for (int i = 0; i < positions.Length; i++)
        // {
        //     GameObject obj = Instantiate(panelPrefab, positions[i], quat, gameObject.transform);
        //     obj.transform.Rotate(0.0f, positions[i].w, 0.0f);
        //     obj.transform.parent = gameObject.transform;
        //     obj.GetComponent<FadeInPanel>().Appear();
        //     panels[i] = obj;
        // }

        // gameObject.transform.position = oldPosition;
        HideAll();

    }

    public void ShowAll()
    {
        for (int i = 0; i < this.panels.Length; i++)
        {
            ShowPanel(i);
        }
    }
    public void HideAll()
    {
        for (int i = 0; i < this.panels.Length; i++)
        {
            if (this.panels[i])
                HidePanel(i);
        }
    }

    public void SetPosition(int i, Vector3 position)
    {
        GameObject panel = panels[i];
        Transform panelTransform = panel.GetComponent<Transform>();
        panelTransform.position = position;
        positions[i] = position;
    }


    public void ShowPanel(int i)
    {
        GameObject panel = panels[i];
        panel.SetActive(true);
        panel.GetComponentInChildren<FadeInPanel>().Appear();
    }

    public void HidePanel(int i)
    {
        GameObject panel = panels[i];
        // panel.SetActive(false);
        panel.GetComponentInChildren<FadeInPanel>().Disappear();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
