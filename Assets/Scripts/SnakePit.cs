using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePit : MonoBehaviour
{

    public GameObject[] snakePrefabs;

    public int count = 10;



    // Use this for initialization
    void Start()
    {
        Transform transform = GetComponent<Transform>();
        GameObject prefab;
        for (int i = 0; i < count; i++)
        {
            prefab = snakePrefabs[Mathf.RoundToInt(Random.RandomRange(0, (float)snakePrefabs.Length - 1))];


            GameObject snake = Instantiate(prefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, transform);
            ExampleLineRenderer renderer = snake.GetComponent<ExampleLineRenderer>();
            renderer.flip = Random.Range(0.0f, 1.0f) > 0.5f;
            renderer.maxLength = Mathf.RoundToInt(Random.Range(renderer.maxLength * 0.5f, renderer.maxLength * 1.5f));
            renderer.period = Random.Range(renderer.period * 0.5f, renderer.period * 1.5f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
