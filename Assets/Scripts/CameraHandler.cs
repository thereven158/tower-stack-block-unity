using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHandler : MonoBehaviour
{
     
    private Vector3 temp;
    bool gameNotPlayed = true;

    public GameObject ButtonStart;
    public GameObject ButtonRetry;

    // Start is called before the first frame update
    void Start()
    {
        temp = this.transform.localPosition;
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
        
    }
    
    void CameraGoesUp()
    {
        temp.y = (this.transform.localPosition.y + 1.02f);

        this.transform.localPosition = temp;
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
