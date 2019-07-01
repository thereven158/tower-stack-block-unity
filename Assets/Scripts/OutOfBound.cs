using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{

    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cube = GameObject.Find("Cube");
        
    }

    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.name == "Cube")
        {
            Destroy(Cube);
        }
    }
}
