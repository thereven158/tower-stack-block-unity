using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanges : MonoBehaviour
{
    float hue;
    float saturation;
    float value;

    public GameObject ObjOutOfBound;
    float GetCurrentHue;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        ObjOutOfBound = GameObject.Find("OutOfBound");
        OutOfBound outOfBound = ObjOutOfBound.GetComponent<OutOfBound>();
        GetCurrentHue = outOfBound.Hue;

        hue = GetCurrentHue;
        saturation = 0.6f;
        value = 0.9f;
        rend = GetComponent<Renderer>();
        //rend.material.color = Random.ColorHSV(hue, 1f, 0.6f, 0.6f, 0.9f, 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale == 0) return;
            hue += 0.02f;
            //rend.material.color = Random.ColorHSV(hue, hue, 0.59f, 0.59f, 0.95f, 0.95f);
            rend.material.color = Color.HSVToRGB(hue, saturation, value);
        }
    }
}
