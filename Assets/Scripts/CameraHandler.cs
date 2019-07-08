﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHandler : MonoBehaviour
{

    private Vector3 _tempStart;
    private Vector3 _tempEnd;
    bool gameNotPlayed = true;

    public GameObject ButtonStart;
    public GameObject ButtonRetry;

    // Transforms to act as start and end markers for the journey.
    public Transform EndMarker;

    // Movement speed in units/sec.
    public float Speed = 1.0F;


    // Start is called before the first frame update
    void Start()
    {
        _tempEnd = EndMarker.transform.localPosition;
        ButtonRetry.SetActive(false);
        NotPlaying();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameNotPlayed) return;

            CameraGoesUp();
        }

        // Move our position a step closer to the target.
        float step = Speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, EndMarker.position, step);
    }
    
    void CameraGoesUp()
    {
        //_temp.y = (this.transform.localPosition.y + 1.02f);

        //this.transform.localPosition = _temp;

        _tempEnd.y = (EndMarker.transform.localPosition.y + 1.02f);

        EndMarker.transform.localPosition = _tempEnd;
    }

    void CameraGoesUpSlowly()
    {
        
    }

    public void NotPlaying()
    {
        Time.timeScale = 0f;
        gameNotPlayed = true;
    }

    public void Playing()
    {
        Time.timeScale = 1f;
        ButtonStart.SetActive(false);
        gameNotPlayed = false;
        ButtonRetry.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameNotPlayed = true;
        ButtonRetry.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }
}
