using UnityEngine;
using Agate.GameServer.Responses;
using System;

public class RegisterManager : MonoBehaviour
{
    public void SubmitRegister(string username, string pass, int firstScore, int timer, Action<RegisterResponse> callback = null)
    {
        SubmitRegisterRequest request = new SubmitRegisterRequest();
        request.OnComplete += (response) =>
        {
            if (callback != null) callback.Invoke(response);
        };
        request.SendRequest(username, pass, firstScore, timer);
    }
}
