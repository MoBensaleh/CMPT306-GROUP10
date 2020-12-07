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
        if (!PlayerPrefs.HasKey("prevLevelTime"))
        {
            PlayerPrefs.SetFloat("prevLevelTime", timer);
            PlayerPrefs.Save();
        }
        else
        {
            timer = PlayerPrefs.GetFloat("prevLevelTime");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = PlayerPrefs.GetFloat("prevLevelTime");
        timer += Time.deltaTime;
        PlayerPrefs.SetFloat("prevLevelTime", timer);
        PlayerPrefs.Save();
        minutes = (int)(timer / 60f);
        seconds = (int)(timer % 60f);
        counterText.text = (minutes).ToString("00") + ":" + (seconds).ToString("00");
    }
}
