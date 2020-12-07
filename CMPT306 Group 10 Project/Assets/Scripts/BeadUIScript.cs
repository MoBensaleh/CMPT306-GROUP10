using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeadUIScript : MonoBehaviour
{
    Text text;
    public static int beadTotal;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerBeadPouch.beadTotal.ToString();
    }
}
