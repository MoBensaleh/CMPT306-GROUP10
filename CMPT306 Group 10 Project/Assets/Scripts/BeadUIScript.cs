using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeadUIScript : MonoBehaviour
{
    Text text;
    TextMesh textyBoi;
    public static int beadTotal;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Text>()) {
            text = GetComponent<Text>();
            Debug.Log("Text");
        }
        else {
            textyBoi = GetComponent<TextMesh>();
            Debug.Log("Text Mesh");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Text>()) {
            text.text = PlayerBeadPouch.beadTotal.ToString();
        }
        else {
            textyBoi.text = PlayerBeadPouch.beadTotal.ToString();
        }
        
    }
}
