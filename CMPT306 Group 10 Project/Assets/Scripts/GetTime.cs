using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour {

    public Text textbox;
    
    // Start is called before the first frame update
    void Start() {
        textbox = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = (PlayerPrefs.GetFloat("prevLevelTime")).ToString();
    }
}
