using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanges : MonoBehaviour
{
    float hue;

    // Start is called before the first frame update
    void Start()
    {
        hue = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hue += 0.01f;
            GetComponent<Renderer>().material.color = Random.ColorHSV(hue, 1f, 0.59f, 0.59f, 0.95f, 0.95f);
        }
    }
}
