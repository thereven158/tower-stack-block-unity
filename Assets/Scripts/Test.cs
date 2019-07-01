using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.GameServer.Responses;

public class Test : MonoBehaviour
{
    private RegisterManager registerManager;

    [Header("Register")]
    public string Username;
    public string Pass;
    private int firstScore = 0;

    private void Awake()
    {
        registerManager = new RegisterManager();
    }

    public void Register()
    {
        registerManager.SubmitRegister(Username, Pass, firstScore, 1000);
    }
}
