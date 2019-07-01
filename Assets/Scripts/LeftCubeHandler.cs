using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCubeHandler : MonoBehaviour
{

    Rigidbody rB;
    GameObject cutItRight;
    GameObject cutItLeft;
    GameObject cameraObj;
    CameraHandler cameraHandler;

    public float speed = 5;
    private bool dirRight = true;
    private bool moving = true;

    Vector3 rightPoint;
    Vector3 leftPoint;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        rB.isKinematic = true;

        cutItRight = GameObject.Find("CutItRight");
        cutItLeft = GameObject.Find("CutItLeft");
    }

    // Update is called once per frame
    void Update()
    {
        leftPoint = this.transform.position - Vector3.right * this.transform.localScale.x / 2;
        rightPoint = this.transform.position + Vector3.right * this.transform.localScale.x / 2;
        
        Moving();
        if (Input.GetMouseButtonDown(0))
        {
            cameraObj = GameObject.Find("Camera");
            cameraHandler = cameraObj.GetComponent<CameraHandler>();
            if (leftPoint.x > cutItRight.transform.position.x)
            {
                cameraHandler.GameOver();
            }
            else if (rightPoint.x < cutItLeft.transform.position.x)
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
        //back and forth
        if (moving)
        {
            if (dirRight)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
            {
                this.transform.Translate(-Vector3.right * Time.deltaTime * speed);
            }

            if (transform.position.x > 0.4f)
            {
                dirRight = false;
            }

            if (transform.position.x < -9.62f)
            {
                dirRight = true;
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
