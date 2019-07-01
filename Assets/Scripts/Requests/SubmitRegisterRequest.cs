using UnityEngine;
using Agate.GameServer.Messages;
using Agate.GameServer.Models;
using Agate.GameServer.Responses;
using Agate.Onyx.Core.Utils;
using UnityEngine.Events;

public class SubmitRegisterRequest
{
    public UnityAction<RegisterResponse> OnComplete;
    private HttpRequest httpRequest;

    public SubmitRegisterRequest()
    {
        httpRequest = new HttpRequest();
        httpRequest.OnRequestDone.AddListener(OnRequestDone);
    }

    public void SendRequest(string username, string pass, int firstScore, int timer)
    {
        string url = ServerApiUrl.Instance.WaskitaGameServerUrl + ServerApiUrl.Instance.SubmitRegister;
        NewUser message = new NewUser();
        message.User = new User();
        message.User.Username = username;
        message.User.Pass = pass;
        message.User.Score = firstScore;
        message.Timer = timer;

        message = MessageHelper.WrapMessage(message) as NewUser;
        httpRequest.DoHttpPostRequest(url, message);
    }

    private void OnRequestDone()
    {
        Debug.Log(httpRequest.Output);
        RegisterResponse response;
        if (httpRequest.IsError)
        {
            response = new RegisterResponse();

        }
        else
        {
            response = Agate.Onyx.Core.Utils.JsonUtility.Decode<RegisterResponse>(httpRequest.Output);
            if (response == null)
            {
                response = new RegisterResponse();

            }
        }
        if (OnComplete != null)
            OnComplete(response);
    }
}