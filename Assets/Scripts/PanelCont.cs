using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelCont : MonoBehaviour
{
    public int PanelCount;
    int PitchBest;
    public int PitchNow;
    TextMeshPro Pitches;
    TextMeshPro Cong;
    TextMeshPro SpeedText;
    TextMeshPro BestUp;
    TextMeshPro RestartText;
    public float speed;
    public bool changeSpeed;
    float now;
    
    // Start is called before the first frame update
    void Start()
    {
        PanelCount = 0;
        PitchBest = PlayerPrefs.GetInt ("SCORE", 999);
        PitchNow = 0;
        Pitches = GameObject.Find("Pitches").GetComponent<TextMeshPro>();
        Cong = GameObject.Find("Cong").GetComponent<TextMeshPro>();
        Cong.gameObject.SetActive(false);
        BestUp = GameObject.Find("BestUp").GetComponent<TextMeshPro>();
        BestUp.gameObject.SetActive(false);
        RestartText = GameObject.Find("RestartText").GetComponent<TextMeshPro>();
        RestartText.gameObject.SetActive(false);
        SpeedText = GameObject.Find("Speed").GetComponent<TextMeshPro>();
        now = 0.0f;
        changeSpeed = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (PanelCount == 9)
        {
            Cong.gameObject.SetActive(true);
            RestartText.gameObject.SetActive(true);
            if (PitchBest > PitchNow)
            {
                BestUp.gameObject.SetActive(true);
                PlayerPrefs.SetInt ("SCORE", PitchNow);
                PlayerPrefs.Save ();
            }
        }

        now += Time.deltaTime;
        if (now >= 3.0f)
        {
            SpeedText.text = "";
        }
    }

    void LateUpdate ()
    {
        Pitches.text = "Pitches\r\nBest : " + PitchBest.ToString("d")
                + "\r\nNow : " + PitchNow.ToString("d");

        if (changeSpeed)
        {
            SpeedText.text = speed.ToString("f1") + " km/h";
            now = 0.0f;
            changeSpeed = false;
        }
    }
}
