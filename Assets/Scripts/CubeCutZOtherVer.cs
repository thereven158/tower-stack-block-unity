using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCutZOtherVer : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    GameObject cube;

    Vector3 middleTemp;
    Vector3 leftSpawnCube;
    GameObject cubeCutFrontPosition;
    GameObject cubeCutBackPosition;
    GameObject middlePoint;
    GameObject getText;

    private string curAmount;
    int counter;
    public Text Score;
    int highScore;
    string highScoreKey = "HighScore";

    public GameObject ButtonRetry;

    bool purfectFront = false;
    bool purfectBack = false;

    void Start()
    {
        cubeCutFrontPosition = GameObject.Find("CutItFront");
        cubeCutBackPosition = GameObject.Find("CutItBack");
        middlePoint = GameObject.Find("MiddlePoint");
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        cube = GameObject.Find("Cube");
    }

    void Update()
    {
        cube = GameObject.Find("Cube");
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
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
            //Debug.Log("Mashok Purrrfect front cube");
            if (rightVictimPoint.z > cubeCutBackPosition.transform.position.z - 0.2f && rightVictimPoint.z < cubeCutBackPosition.transform.position.z && purfectFront)
            {
                //Debug.Log("Purrrfect front cube");
                ShowFloatingText();

                //Destroy back side
                Destroy(backSideObj);

                //Transform position Middle Point Object
                middleTemp = new Vector3(frontSideObj.transform.localPosition.x, frontSideObj.transform.localPosition.y, frontSideObj.transform.localPosition.z);
                middlePoint.transform.position = middleTemp;
                //middleTemp = middlePoint.transform.position;
                //middlePoint.transform.position = middleTemp;

                //Custom frontSideObj to perfect size
                frontSideObj.transform.localPosition = middleTemp;
                frontSideObj.transform.localScale = victimScale;


                //Change name object
                Rigidbody rigidFront = frontSideObj.GetComponent<Rigidbody>();
                frontSideObj.name = "FrontClone";
                rigidFront.constraints = RigidbodyConstraints.FreezeAll;

                //Set Spawn on left side
                leftSpawnCube = frontSideObj.transform.localPosition;
                leftSpawnCube.y = (frontSideObj.transform.localPosition.y + 1f);
                leftSpawnCube.x = (frontSideObj.transform.localPosition.x - 5.06f);

                //Clone Object
                GameObject clone = Instantiate(frontSideObj, leftSpawnCube, Quaternion.identity);
                clone.name = "LeftCube";
                clone.AddComponent<LeftCubeHandler>();
                clone.AddComponent<ColorChanges>();
                

                //Transform position Cube Cut Back
                cubeCutFrontPosition.transform.position = frontSideObj.transform.position + frontSideObj.transform.forward * frontSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutFrontPosition.transform.position += temp;
                cubeCutBackPosition.transform.position += temp;
            }
            //Not Purfect
            else
            {
                //Change name object
                Rigidbody rigidFront = frontSideObj.GetComponent<Rigidbody>();
                frontSideObj.name = "FrontClone";

                //Transform position Middle Point Object
                middleTemp = new Vector3(frontSideObj.transform.localPosition.x, frontSideObj.transform.localPosition.y, frontSideObj.transform.localPosition.z);
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
                cubeCutFrontPosition.transform.position = frontSideObj.transform.position + frontSideObj.transform.forward * frontSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutFrontPosition.transform.position += temp;
                cubeCutBackPosition.transform.position += temp;
            }
            Destroy(cube);
        }

        //if victim over than middle point toward front
        if (victim.position.z > middlePoint.transform.position.z)
        {
            //Purfect back side
            Vector3 leftVictimPoint = victim.position - Vector3.back * victim.localScale.z / 2;
            purfectBack = true;
            //Debug.Log("Mashok Purrrfect back cube");

            //if (victim.position.z < middlePoint.transform.position.z + 0.2f && purfectBack)
            if (leftVictimPoint.z < cubeCutFrontPosition.transform.position.z + 0.2f && purfectBack)
            {
                //Debug.Log("Purrrfect back cube");
                ShowFloatingText();

                //Destroy front side
                Destroy(frontSideObj);

                //Transform position Middle Point Object
                middleTemp = new Vector3(backSideObj.transform.localPosition.x, backSideObj.transform.localPosition.y, backSideObj.transform.localPosition.z);
                middlePoint.transform.position = middleTemp;

                //Custom backSideObj to perfect size
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
                cubeCutFrontPosition.transform.position = backSideObj.transform.position + backSideObj.transform.forward * backSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutFrontPosition.transform.position += temp;
                cubeCutBackPosition.transform.position += temp;
            }
            //Not Purfect
            else
            {
                //Change name object
                Rigidbody rigidBack = backSideObj.GetComponent<Rigidbody>();
                backSideObj.name = "BackClone";

                Vector3 addPosition = new Vector3(0f, 0f, 0.05f);
                frontSideObj.transform.position += addPosition;

                //Set Spawn on left side
                leftSpawnCube = backSideObj.transform.localPosition;
                leftSpawnCube.y = (backSideObj.transform.localPosition.y + 1f);
                leftSpawnCube.x = (backSideObj.transform.localPosition.x - 5.06f);

                //Transform position Middle Point Object
                middleTemp = new Vector3(backSideObj.transform.localPosition.x, backSideObj.transform.localPosition.y, backSideObj.transform.localPosition.z);
                middlePoint.transform.position = middleTemp;

                //Clone Object
                GameObject clone = Instantiate(backSideObj, leftSpawnCube, Quaternion.identity);
                clone.name = "LeftCube";
                clone.AddComponent<LeftCubeHandler>();
                clone.AddComponent<ColorChanges>();
                rigidBack.constraints = RigidbodyConstraints.FreezeAll;

                //Transform position Cube Cut Front
                cubeCutBackPosition.transform.position = backSideObj.transform.position - backSideObj.transform.forward * backSideObj.transform.localScale.z / 2;
                Vector3 temp = new Vector3(0, 2f, 0);
                cubeCutBackPosition.transform.position += temp;
                cubeCutFrontPosition.transform.position += temp;
            }
        }

        //return true;
    }

    private void OnCollisionEnter(Collision target)
    {
        //Scoring
        getText = GameObject.Find("CurrentScore");
        curAmount = getText.GetComponent<Text>().text;
        counter = int.Parse(curAmount);

        if (counter > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, counter);
            PlayerPrefs.Save();
        }

        //Get Cut
        if (target.transform.name == ("RightCube"))
        {

            counter++;
            Score.text = counter + "";

            Cut(target.transform, transform.position);
        }
    }


}
