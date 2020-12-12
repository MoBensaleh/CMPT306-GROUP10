using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlayerSpeed : MonoBehaviour
{
    float delayTime;
    int maxTime = 10;
    bool didBoost = false;


    public void Start()
    {

        delayTime = 0;
    }
    // Start is called before the first frame update
    public void Update()
    {

        if (delayTime < maxTime && didBoost)
        {
            IncreaseSpeed();
            delayTime += Time.deltaTime;
        }
        else
        {
            NormalSpeed();
            didBoost = false;
            delayTime = 0;
        }


    }

    public void StartBoost()
    {

        if (delayTime < maxTime)
        {
            IncreaseSpeed();

        }
        else
        {

            NormalSpeed();
        }
    }
    public void IncreaseSpeed()
    {



        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerMovement>().SetMoveSpeed(10.0f);
        didBoost = true;



    }
    public void NormalSpeed()
    {


        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerMovement>().SetMoveSpeed(5.0f);
       



    }
}
