using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCubeHandler : MonoBehaviour
{

    public float speed = 5;
    private bool dirLeft = true;
    private bool moving = true;

    Rigidbody rB;
    GameObject cutItBack;
    GameObject cutItFront;
    GameObject cameraObj;
    CameraHandler cameraHandler;
    Vector3 frontPoint;
    Vector3 backPoint;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        rB.isKinematic = true;

        cutItBack = GameObject.Find("CutItBack");
        cutItFront = GameObject.Find("CutItFront");
    }

    // Update is called once per frame
    void Update()
    {
        frontPoint = this.transform.position - Vector3.back * this.transform.localScale.z / 2;
        backPoint = this.transform.position + Vector3.back * this.transform.localScale.z / 2;
        Moving();
        if (Input.GetMouseButtonDown(0))
        {
            cameraObj = GameObject.Find("Camera");
            cameraHandler = cameraObj.GetComponent<CameraHandler>();
            if (frontPoint.z < cutItBack.transform.position.z)
            {
                cameraHandler.GameOver();
            }
            else if (backPoint.z > cutItFront.transform.position.z)
            {
                cameraHandler.GameOver();
            }
            else
            {
                Clicked();
            }
        }
    }

    void Moving()
    {
        if (moving)
        {
            //back and forth
            if (dirLeft)
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
            else
            {
                transform.Translate(-Vector3.back * Time.deltaTime * speed);
            }

            if (transform.position.z > 9.6f)
            {
                dirLeft = true;
            }

            if (transform.position.z < -0.5f)
            {
                dirLeft = false;
            }
        }
        else
        {
            //this.transform.Translate(Vector3.zero);
            this.transform.Translate(Vector3.right * Time.deltaTime * 0);
        }
    }

    public void Clicked()
    {
        rB.constraints = RigidbodyConstraints.FreezeAll;
        rB.isKinematic = false;

        moving = false;
    }

    
}
