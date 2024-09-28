
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float forwardSpeed = 20;
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    { 
        //Player.transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        Player.transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }

    public void PlayerMove(float turnSpeed)
    {
        Player.transform.Translate(new Vector3(turnSpeed,0,0) * Time.deltaTime);
    }
    
}
