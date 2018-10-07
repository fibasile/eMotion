using UnityEngine;
using System.Collections;
using System;

public class ExampleLineRenderer : MonoBehaviour
{
    public float width = 0.1f;
    public bool useCurve = true;

    public bool flip = false;


    public Vector2 bounds;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;


    public int maxLength = 10; // 10 segments max
    public float step = 0.5f;

    private LineRenderer lr;

    private int currentLength = 2;

    public Vector3[] positions;

    private float startY;

    private bool needsUpdate;



    private Vector3 worldSpace;

    void Start()
    {


        lr = GetComponent<LineRenderer>();
        // lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = width;
        needsUpdate = false;


        Spawn();
    }

    void Spawn()
    {

        worldSpace = transform.parent.parent.position;

        float gridPoint = UnityEngine.Random.Range(-bounds.y, bounds.y);

        gridPoint = Mathf.Round(gridPoint / 0.5f) * 0.5f;

        // float z = UnityEngine.Random.Range(-1.0f, 1.0f);

        startY = gridPoint + 0.25f;
        positions = new Vector3[2];
        positions[0] = new Vector3(0, gridPoint + 0.25f, worldSpace.z);
        positions[1] = new Vector3(flip ? -1 * step : step, gridPoint + 0.25f, worldSpace.z);

        if (flip)
        {
            positions[0].Scale(new Vector3(-1.0f, 1.0f, 1.0f));
            positions[1].Scale(new Vector3(-1.0f, 1.0f, 1.0f));

        }
        positions[0].Set(positions[0].x + worldSpace.x, positions[0].y, positions[0].z);
        positions[1].Set(positions[1].x + worldSpace.x, positions[1].y, positions[1].z);
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);
        currentLength = positions.Length;
    }

    void UpdateLine()
    {

        currentLength++;
        needsUpdate = true;

        // check if all the points are outside bounds
        // in this case reset / respawn on the right

        // # move the line left


    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            UpdateLine();
        }

        if (needsUpdate)
        {
            Vector3[] newPositions = new Vector3[currentLength + 1];

            float deltaX = -1.0f * step;
            float deltaY = 0.0f;

            if (flip) deltaX = deltaX * -1.0f;

            float seed = UnityEngine.Random.Range(0.0f, 1.0f);

            if (positions[0].y == startY && positions[1].y == startY)
            {
                if (seed != 0 && seed < 0.1f) deltaY += 0.5f;
                if (seed > 0.9f) deltaY -= 0.5f;
            }
            else if (positions[0].y > startY && positions[1].y != startY)
            {
                if (seed > 0.85f) deltaY -= 0.5f;
            }
            else if (positions[0].y > startY && positions[1].y != startY)
            {
                if (seed < 0.85f) deltaY += 0.5f;
            }

            newPositions[0] = new Vector3(positions[0].x + deltaX, positions[0].y + deltaY, positions[0].z);
            positions.CopyTo(newPositions, 1);



            // for (int i = 1; i < positions.Length + 1; i++)
            // {
            //     Vector3 oldPos = positions[i - 1];
            //     newPositions[i] = oldPos;
            // }

            if (currentLength > maxLength)
            {
                // Debug.Log("Trim length");
                currentLength = maxLength;
            }
            lr.positionCount = currentLength;
            Array.Resize(ref newPositions, currentLength);
            lr.SetPositions(newPositions);
            positions = newPositions;


            bool allOut = true;
            for (int i = 0; i < positions.Length; i++)
            {
                // Vector3 normPosition = new Vector3(positions[i].x, positions[i].y, positions[i].z);
                if (positions[i].x > (-1.0f * bounds.x) + worldSpace.x && positions[i].x - worldSpace.x < bounds.x)
                {
                    // Debug.Log("Found one in " + positions[i].x + " > " + -1.0f * bounds.x);
                    allOut = false;
                }
            }

            if (allOut)
            {
                Spawn();
            }

            needsUpdate = false;
        }

        // first add a new point on the front
        // could be + or - offset or zero
        // now trim the length to the maximum length

        AnimationCurve curve = new AnimationCurve();
        if (useCurve)
        {
            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 0.0f);
        }
        else
        {
            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 1.0f);
        }

        lr.widthCurve = curve;
    }
    // AnimationCurve curve = new AnimationCurve();
    // if (useCurve)
    // {
    //     curve.AddKey(0.0f, 0.0f);
    //     curve.AddKey(1.0f, 1.0f);
    // }
    // else
    // {
    //     curve.AddKey(0.0f, 1.0f);
    //     curve.AddKey(1.0f, 1.0f);
    // }

    // lr.widthCurve = curve;
    // lr.widthMultiplier = width;
    // }

    // void OnGUI()
    // {
    //     GUI.Label(new Rect(25, 20, 200, 30), "Width");
    //     width = GUI.HorizontalSlider(new Rect(125, 25, 200, 30), width, 0.1f, 1.0f);
    //     useCurve = GUI.Toggle(new Rect(25, 65, 200, 30), useCurve, "Use Curve");
    // }
}