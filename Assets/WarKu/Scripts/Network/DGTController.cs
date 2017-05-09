﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGTController : MonoBehaviour {

    #region constant
    /**
     * @HOST host of Server
     * @PORT port of Gateway Server
     **/
    const string HOST = "localhost";
    const int PORT = 1000;
    #endregion

    #region remotes
    /**
     * Remotes as attributes for DRY purpose
     **/ 
    GatewayRemote gatewayRemote;
    #endregion

    #region unity method
    // Use this for initialization
    void Start()
    {
        InitializeRemotes();
        StartCoroutine(ConnectToGateway());
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRemote();
    }
    
    // Call when exit application
    void OnApplicationQuit()
    {
        gatewayRemote.Disconnect();
    }
    #endregion

    #region remote processing method
    /**
     * Assign Remotes to Attributes for DRY purpose
     **/
    void InitializeRemotes()
    {
        gatewayRemote = GatewayRemote.GetInstance();
    }

    /**
     * Process Event for each remotes
     **/
    void ProcessRemote()
    {
        gatewayRemote.ProcessEvents();
    }
    #endregion

    #region connection
    /**
     * Connect to Gateway Server
     **/
    IEnumerator ConnectToGateway()
    {
        //Start Connection to Gateway server at HOST : PORT
        gatewayRemote.Connect(HOST, PORT);
        
        // Try to connect atmost 10 times
        for (int i = 0; i < 10; i++)
        {
            if (gatewayRemote.IsConnected() || gatewayRemote.IsConnectionFailed()) break;
            gatewayRemote.ProcessEvents();
            yield return new WaitForSeconds(0.5f);
        }

        // Connection Success / Not
        gatewayRemote.CheckConnection();
        yield break;
    }
    #endregion

}
