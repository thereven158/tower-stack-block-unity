using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointHandler : MonoBehaviour
{

    public GameObject LeftCube;
    public GameObject RightCube;
    private bool _summonLeft = true;

    Transform spawnLeft, spawnRight;
    Vector3 tempLeft, tempRight;

    


    // Start is called before the first frame update
    void Start()
    {
        spawnLeft = this.transform.Find("SpawnLeft");
        spawnRight = this.transform.Find("SpawnRight");
        tempLeft = spawnLeft.transform.localPosition;
        tempRight = spawnRight.transform.localPosition;
        
        Invoke("SpawnCubeRight", 0.5f);       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    public void SpawnCubeLeft()
    {
        GameObject clone = Instantiate(LeftCube, tempLeft, Quaternion.identity);
        clone.name = "LeftCube";
        //Invoke("SpawnCubeRight", 2.5f);
    }

    public void SpawnCubeRight()
    {
        GameObject clone = Instantiate(RightCube, tempRight, Quaternion.identity);
        clone.name = "RightCube";
    }

    public void SpawnMoved()
    {
        tempLeft.y = (spawnLeft.transform.localPosition.y + 1f);
        tempRight.y = (spawnRight.transform.localPosition.y + 1f);

        spawnLeft.transform.localPosition = tempLeft;
        spawnRight.transform.localPosition = tempRight;

    }
}
