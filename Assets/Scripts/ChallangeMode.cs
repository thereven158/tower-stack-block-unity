using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeMode : MonoBehaviour
{

    LeftCubeHandler leftCubeHandler;
    RightCubeHandler rightCubeHandler;
    GameObject leftCube;
    GameObject rightCube;

    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leftCube = GameObject.Find("LeftCube");
            rightCube = GameObject.Find("RightCube");
            leftCubeHandler = leftCube.GetComponent<LeftCubeHandler>();
            rightCubeHandler = rightCube.GetComponent<RightCubeHandler>();
            speed += 0.1f;
            if(leftCube != null)
            {
                leftCubeHandler.speed = speed;
            }
            if(rightCube != null)
            {
                rightCubeHandler.speed = speed;
            }
        }
    }
}
