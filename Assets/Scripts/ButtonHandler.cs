using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeadClicked()
    {
        Debug.Log("KeKlik");
    }

    public void ChallangeMode(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
