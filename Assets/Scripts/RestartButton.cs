using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    bool Push;
    float max;
    float now;
    GameObject Mark;
    Image Gauge;

    void Start ()
    {
        Push = false;
        max = 1.0f;
        now = 0.0f;
        Mark = GameObject.Find("ResetMark");
        Gauge = GameObject.Find("ResetGauge").GetComponent<Image>();
        Mark.SetActive (false);
    }

    void Update ()
    {
        // ボタンを押したら画像を表示させ、nowを数え始める
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            Push = true;
            Mark.SetActive (true);
        }
        // ボタンを離したらnowを0に戻し、画像を非表示にする
        else if (OVRInput.GetUp(OVRInput.RawButton.Y))
        {
            Push = false;
            now = 0.0f;
            Mark.SetActive (false);
        }

        if (Push)
        {
            now += Time.deltaTime;
            Gauge.fillAmount = now / max;
            // ボタンを1秒継続して押されていたらリスタート
            if (now >= max)
            {
                SceneManager.LoadScene ("Main");
            }
        }
    }
}
