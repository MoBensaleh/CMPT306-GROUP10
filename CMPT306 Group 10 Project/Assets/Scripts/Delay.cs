using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    float delayTime;
    int maxTime = 10;
    bool didExtendVision = false;


    public void Start()
    {
        
        delayTime = 0;
    }
    // Start is called before the first frame update
    public void Update()
    {

        if (delayTime < maxTime && didExtendVision)
        {
            ExtendVision();
            delayTime += Time.deltaTime;
            Debug.Log(delayTime);
           

        }
        else
        {
            NormalVision();
            didExtendVision = false;
            delayTime = 0;
        }
    

    }

    public void StartAwakening()
    {
        
        if (delayTime < maxTime)
        {
            ExtendVision();

        }
        else
        {
            
            NormalVision();
        }
    }
    public void ExtendVision()
    {


        
        GameObject fieldOfView = GameObject.Find("FOV");
        fieldOfView.GetComponent<FieldOfView>().SetFoV(90f);
        fieldOfView.GetComponent<FieldOfView>().SetViewDistance(7f);
        didExtendVision = true;



    }
    public void NormalVision()
    {
        
        
        GameObject fieldOfView = GameObject.Find("FOV");
        fieldOfView.GetComponent<FieldOfView>().SetFoV(70f);
        fieldOfView.GetComponent<FieldOfView>().SetViewDistance(4.5f);
        
        

    }
}

  



