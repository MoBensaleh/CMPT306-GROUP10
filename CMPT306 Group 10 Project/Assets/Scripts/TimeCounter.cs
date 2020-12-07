using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text counterText;

    public float timer = 0.0f;

    public float seconds, minutes;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        minutes = (int)(timer / 60f);
        seconds = (int)(timer % 60f);
        counterText.text = (minutes).ToString("00") + ":" + (seconds).ToString("00");
    }
}
