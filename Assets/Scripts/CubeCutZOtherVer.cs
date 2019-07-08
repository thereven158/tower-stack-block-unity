using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCutZOtherVer : MonoBehaviour
{

    Vector3 temp;
    Vector3 middleTemp;
    Vector3 leftSpawnCube;
    GameObject cubeCutFrontPos;
    GameObject cubeCutBackPos;
    GameObject middlePoint;
    GameObject cube;
    bool purfectFront = false;
    bool purfectBack = false;

    void Start()
    {
        temp = this.transform.localPosition;
        cubeCutFrontPos = GameObject.Find("CutItFront");
        cubeCutBackPos = GameObject.Find("CutItBack");
        middlePoint = GameObject.Find("MiddlePoint");
    }

    void Update()
    {

    }

    public void Cut(Transform victim, Vector3 _pos)
    {
        Vector3 pos = new Vector3(victim.position.x, victim.position.y, _pos.z);
        Vector3 victimScale = victim.localScale;

        float distance = Vector3.Distance(victim.position, pos);

        if (distance >= victimScale.z / 2) return; //false;

        Vector3 leftPoint = victim.position - Vector3.back * victimScale.z / 2;
        Vector3 rightPoint = victim.position + Vector3.back * victimScale.z / 2;
        Material mat = victim.GetComponent<MeshRenderer>().material;

        Destroy(victim.gameObject);

        //Divide into 2 cube
        //Back Side
        GameObject backSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        backSideObj.transform.position = (rightPoint + pos) / 2;
        float backWidth = Vector3.Distance(pos, rightPoint);
        backSideObj.transform.localScale = new Vector3(victimScale.x, victimScale.y, backWidth);
        backSideObj.AddComponent<Rigidbody>().mass = 100f;
        backSideObj.GetComponent<MeshRenderer>().material = mat;


        //Front Side
        GameObject frontSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        frontSideObj.transform.position = (leftPoint + pos) / 2;
        float frontWidth = Vector3.Distance(pos, leftPoint);
        frontSideObj.transform.localScale = new Vector3(victimScale.x, victimScale.y, frontWidth);
        frontSideObj.AddComponent<Rigidbody>().mass = 100f;
        frontSideObj.GetComponent<MeshRenderer>().material = mat;

        //if victim over than middle point toward back
        if (victim.position.z < middlePoint.transform.position.z)
        {
            //Purfect front side
            Vector3 rightVictimPoint = victim.position + Vector3.back * victim.localScale.z / 2;
            purfectFront = true;
            if (rightVictimPoint.z > middlePoint.transform.position.z - 0.2f && purfectFront)
            {
                cube = GameObject.Find("Cube");
                Destroy(cube);
                Debug.Log("Purrrfect front");


                //Transform position Middle Point Object
                middleTemp = new Vector3(frontSideObj.transform.localPosition.x, frontSideObj.transform.localPosition.y, frontSideObj.transform.localPosition.z);
                middlePoint.transform.position = middleTemp;

                //Custom frontSideObj
                frontSideObj.transform.localPosition = middleTemp;
                frontSideObj.transform.localScale = victimScale;


                //Change name object
                Rigidbody rigidFront = frontSideObj.GetComponent<Rigidbody>();
                frontSideObj.name = "FrontClone";

                //Set Spawn on left side
                leftSpawnCube = frontSideObj.transform.localPosition;
                leftSpawnCube.y = (frontSideObj.transform.localPosition.y + 1f);
                leftSpawnCube.x = (frontSideObj.transform.localPosition.x - 5.06f);

                //Clone Object
                GameObject clone = Instantiate(frontSideObj, leftSpawnCube, Quaternion.identity);
                clone.name = "LeftCube";
                clone.AddComponent<LeftCubeHandler>();
                clone.AddComponent<ColorChanges>();
                rigidFront.constraints = RigidbodyConstraints.FreezeAll;

                //Transform position Cube Cut Back
                cubeCutFrontPos.transform.position = frontSideObj.transform.position + frontSideObj.transform.forward * frontSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutFrontPos.transform.position += temp;
                cubeCutBackPos.transform.position += temp;
            }
            //Not Purfect
            else
            {
                //Change name object
                Rigidbody rigidFront = frontSideObj.GetComponent<Rigidbody>();
                frontSideObj.name = "FrontClone";

                //Transform position Middle Point Object
                middleTemp = new Vector3(frontSideObj.transform.localPosition.x, 0f, frontSideObj.transform.localPosition.z);
                middlePoint.transform.position = middleTemp;

                //Set Spawn on left side
                leftSpawnCube = frontSideObj.transform.localPosition;
                leftSpawnCube.y = (frontSideObj.transform.localPosition.y + 1f);
                leftSpawnCube.x = (frontSideObj.transform.localPosition.x - 5.06f);

                //Clone Object
                GameObject clone = Instantiate(frontSideObj, leftSpawnCube, Quaternion.identity);
                clone.name = "LeftCube";
                clone.AddComponent<LeftCubeHandler>();
                clone.AddComponent<ColorChanges>();
                rigidFront.constraints = RigidbodyConstraints.FreezeAll;

                //Transform position Cube Cut Back
                cubeCutFrontPos.transform.position = frontSideObj.transform.position + frontSideObj.transform.forward * frontSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutFrontPos.transform.position += temp;
                cubeCutBackPos.transform.position += temp;
            }
        }

        //if victim over than middle point toward front
        if (victim.position.z > middlePoint.transform.position.z)
        {
            //Purfect back side
            Vector3 leftVictimPoint = victim.position - Vector3.back * victim.localScale.z / 2;
            purfectBack = true;

            //if (victim.position.z < middlePoint.transform.position.z + 0.2f && purfectBack)
            if (leftVictimPoint.z < middlePoint.transform.position.z + 0.2f && purfectBack)
            {
                cube = GameObject.Find("Cube");
                Destroy(cube);
                Debug.Log("Purrrfect back side");


                //Transform position Middle Point Object
                middleTemp = new Vector3(backSideObj.transform.localPosition.x, backSideObj.transform.localPosition.y, backSideObj.transform.localPosition.z);
                middlePoint.transform.position = middleTemp;

                //Custom frontSideObj
                backSideObj.transform.localPosition = middleTemp;
                backSideObj.transform.localScale = victimScale;

                //Change name object
                Rigidbody rigidFront = backSideObj.GetComponent<Rigidbody>();
                backSideObj.name = "BackClone";

                //Set Spawn on left side
                leftSpawnCube = backSideObj.transform.localPosition;
                leftSpawnCube.y = (backSideObj.transform.localPosition.y + 1f);
                leftSpawnCube.x = (backSideObj.transform.localPosition.x - 5.06f);

                //Clone Object
                GameObject clone = Instantiate(backSideObj, leftSpawnCube, Quaternion.identity);
                clone.name = "LeftCube";
                clone.AddComponent<LeftCubeHandler>();
                clone.AddComponent<ColorChanges>();
                rigidFront.constraints = RigidbodyConstraints.FreezeAll;

                //Transform position Cube Cut Back
                cubeCutFrontPos.transform.position = backSideObj.transform.position + backSideObj.transform.forward * backSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutFrontPos.transform.position += temp;
                cubeCutBackPos.transform.position += temp;
            }
            //Not Purfect
            else
            {
                //Change name object
                Rigidbody rigidBack = backSideObj.GetComponent<Rigidbody>();
                backSideObj.name = "BackClone";

                //Set Spawn on left side
                leftSpawnCube = backSideObj.transform.localPosition;
                leftSpawnCube.y = (backSideObj.transform.localPosition.y + 1f);
                leftSpawnCube.x = (backSideObj.transform.localPosition.x - 5.06f);

                //Transform position Middle Point Object
                middleTemp = new Vector3(backSideObj.transform.localPosition.x, 0f, backSideObj.transform.localPosition.z);
                middlePoint.transform.position = middleTemp;

                //Clone Object
                GameObject clone = Instantiate(backSideObj, leftSpawnCube, Quaternion.identity);
                clone.name = "LeftCube";
                clone.AddComponent<LeftCubeHandler>();
                clone.AddComponent<ColorChanges>();
                rigidBack.constraints = RigidbodyConstraints.FreezeAll;

                //Transform position Cube Cut Front
                cubeCutBackPos.transform.position = backSideObj.transform.position - backSideObj.transform.forward * backSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutBackPos.transform.position += temp;
                cubeCutFrontPos.transform.position += temp;
            }
        }

        //return true;
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.transform.name == ("RightCube"))
        {
            Cut(target.transform, transform.position);
        }
    }


}
