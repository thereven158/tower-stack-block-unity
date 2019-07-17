using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField NameField;
    public InputField PassField;
    private int _firstScore = 0;

    public Button SubmitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", NameField.text);
        form.AddField("password", PassField.text);
        form.AddField("hi_score", _firstScore);

        WWW request = new WWW("https://localhost:44375/api/register", form);

        yield return request;

        if(request.text == "0")
        {
            Debug.Log("User creating has successfull.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creating failed. Error: " + request.text);
        }
    }

    public void VerifyInputs()
    {
        SubmitButton.interactable = (NameField.text.Length >= 10 && PassField.text.Length >= 25);
    }
}
