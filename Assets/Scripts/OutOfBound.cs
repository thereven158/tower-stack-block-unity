using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{

    public GameObject Cube;
    public float Hue;
    float saturation;
    float value;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        Hue = 0f;
        saturation = 0.6f;
        value = 0.9f;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Cube = GameObject.Find("Cube");

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale == 0) return;
            Hue += 0.02f;
            //rend.material.color = Random.ColorHSV(hue, hue, 0.59f, 0.59f, 0.95f, 0.95f);
            rend.material.color = Color.HSVToRGB(Hue, saturation, value);
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.name == "Cube")
        {
            Destroy(Cube);
        }
    }
}
