using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{

    public enum matchStates 
    {
        GameOver,
        BallinAction,
        BallReset,
        RPS
    };
    public static matchStates MS;
    matchStates lastMS;
    private InputManager IM;

    // Use this for initialization
    void Start()
    {
        MS = new matchStates();
        IM = gameObject.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (MS)
        {
            case matchStates.GameOver:
                break;
            case matchStates.BallinAction:
                break;
            case matchStates.BallReset:
                break;
            case matchStates.RPS:
                break;
            default:
                break;
        }

        if (lastMS != MS)
        {
            if (lastMS == matchStates.BallinAction)
                freezePlayers();
            else if (MS == matchStates.BallinAction)
                unfreezePlayers();
        }

        lastMS = MS;
    }

    void freezePlayers()
    {
        ///gameObject;
    }

    void unfreezePlayers()
    {

    }
    public static matchStates getMatchStates()
    {
        return MS;
    }
}