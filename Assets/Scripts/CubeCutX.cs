using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCutX : MonoBehaviour
{

    Vector3 temp;
    Vector3 rightSpawnCube;
    Vector3 middleTemp;
    GameObject cubeCutRightPosition;
    GameObject cubeCutLeftPosition;
    GameObject middlePoint;
    GameObject getText;

    private string curAmount;
    int counter;
    public Text Score;
    int highScore;
    string highScoreKey = "HighScore";

    public GameObject ButtonRetry;

    void Start()
    {
        temp = this.transform.localPosition;
        cubeCutRightPosition = GameObject.Find("CutItRight");
        cubeCutLeftPosition = GameObject.Find("CutItLeft");
        middlePoint = GameObject.Find("MiddlePoint");

        highScore = PlayerPrefs.GetInt(highScoreKey, 0);

        Vector3 tempStart = new Vector3(0, 0.5f, 0);
        cubeCutLeftPosition.transform.position += tempStart;
        cubeCutRightPosition.transform.position += tempStart;
    }

    void Update()
    {

    }

    public void Cut(Transform victim, Vector3 _pos)
    {
        Vector3 pos = new Vector3(_pos.x, victim.position.y, victim.position.z);
        Vector3 victimScale = victim.localScale;

        float distance = Vector3.Distance(victim.position, pos);
        if (distance >= victimScale.x / 2) return;//false;

        Vector3 leftPoint = victim.position - Vector3.right * victimScale.x / 2;
        Vector3 rightPoint = victim.position + Vector3.right * victimScale.x / 2;
        Material mat = victim.GetComponent<MeshRenderer>().material;

        Destroy(victim.gameObject);
        
        //Divide into 2 cube
        GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightSideObj.transform.position = (rightPoint + pos) / 2;
        float rightWidth = Vector3.Distance(pos, rightPoint);
        rightSideObj.transform.localScale = new Vector3(rightWidth, victimScale.y, victimScale.z);
        rightSideObj.AddComponent<Rigidbody>().mass = 100f;
        rightSideObj.GetComponent<MeshRenderer>().material = mat;
    
        GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftSideObj.transform.position = (leftPoint + pos) / 2;
        float leftWidth = Vector3.Distance(pos, leftPoint);
        leftSideObj.transform.localScale = new Vector3(leftWidth, victimScale.y, victimScale.z);
        leftSideObj.AddComponent<Rigidbody>().mass = 100f;
        leftSideObj.GetComponent<MeshRenderer>().material = mat;
        //Freeze

        if(victim.position.x > middlePoint.transform.position.x)
        {
            Rigidbody rigidLeft = leftSideObj.GetComponent<Rigidbody>();
            leftSideObj.name = "LeftClone";

            rightSpawnCube = leftSideObj.transform.localPosition;
            rightSpawnCube.y = (leftSideObj.transform.localPosition.y + 1f);
            rightSpawnCube.z = (leftSideObj.transform.localPosition.z + 6f);

            middleTemp = new Vector3(leftSideObj.transform.localPosition.x, 0f, leftSideObj.transform.localPosition.z);
            middlePoint.transform.position = middleTemp;

            GameObject clone = Instantiate(leftSideObj, rightSpawnCube, Quaternion.identity);
            clone.name = "RightCube";
            clone.AddComponent<RightCubeHandler>();
            clone.AddComponent<ColorChanges>();
            rigidLeft.constraints = RigidbodyConstraints.FreezeAll;

            cubeCutLeftPosition.transform.position = leftSideObj.transform.position - leftSideObj.transform.right * leftSideObj.transform.localScale.x / 2;
            Vector3 temp = new Vector3(0, 2f, 0);
            cubeCutLeftPosition.transform.position += temp;
            cubeCutRightPosition.transform.position += temp;
        }
        if (victim.position.x < middlePoint.transform.position.x)
        {
            Rigidbody rigidRight = rightSideObj.GetComponent<Rigidbody>();
            rightSideObj.name = "RightClone";

            rightSpawnCube = rightSideObj.transform.localPosition;
            rightSpawnCube.y = (rightSideObj.transform.localPosition.y + 1f);
            rightSpawnCube.z = (rightSideObj.transform.localPosition.z + 6f);

            middleTemp = new Vector3(rightSideObj.transform.localPosition.x, 0f, rightSideObj.transform.localPosition.z);
            middlePoint.transform.position = middleTemp;

            GameObject clone = Instantiate(rightSideObj, rightSpawnCube, Quaternion.identity);
            clone.name = "RightCube";
            clone.AddComponent<RightCubeHandler>();
            clone.AddComponent<ColorChanges>();
            rigidRight.constraints = RigidbodyConstraints.FreezeAll;

            cubeCutRightPosition.transform.position = rightSideObj.transform.position + rightSideObj.transform.right * rightSideObj.transform.localScale.x / 2;
            Vector3 temp = new Vector3(0, 2f, 0);
            cubeCutRightPosition.transform.position += temp;
            cubeCutLeftPosition.transform.position += temp;
        }
        

        //return true;
    }


    private void OnCollisionEnter(Collision target)
    {
        getText = GameObject.Find("CurrentScore");
        curAmount = getText.GetComponent<Text>().text;
        counter = int.Parse(curAmount);

        if (counter > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, counter);
            PlayerPrefs.Save();
        }

        if (target.transform.name == ("LeftCube"))
        {
            counter++;
            Score.text = counter + "";

            Cut(target.transform, transform.position);
        }
    }
}
