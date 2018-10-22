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
    private InputManager IM1;
    private InputManager IM2;

    // Use this for initialization
    void Start()
    {
        MS = new matchStates();
        GameObject[] player=GameObject.FindGameObjectsWithTag("Player");

        if(player[0].GetComponent<InputManager>().playerOne)
            IM1 = player[0].GetComponent<InputManager>();
        else
            IM2 = player[0].GetComponent<InputManager>();

        if (player[1].GetComponent<InputManager>().playerOne)
            IM1 = player[1].GetComponent<InputManager>();
        else
            IM2 = player[1].GetComponent<InputManager>();
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
        IM1.frozen = true;
        IM2.frozen = true;
    }

    void unfreezePlayers()
    {
        IM1.frozen = false;
        IM2.frozen = false;
    }
    public static matchStates getMatchStates()
    {
        return MS;
    }
}