using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallCont : MonoBehaviour
{
    Rigidbody rigit;
    Vector3 velo;
    Vector3 posi;
    bool throwJudge; // 投げたとみなされた時点でtrueになり、戻る時にfalseになる
    float startx;
    Vector3 stay = new Vector3 (0.0f, 0.0f, 0.0f);
    GameObject Panel;
    PanelCont Script;
    AudioSource ballsound;

    void Start()
    {
        throwJudge = false;
        startx = gameObject.transform.position.x;
        Panel = GameObject.Find("Hubs");
        Script = Panel.GetComponent<PanelCont>();
        ballsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        posi = gameObject.transform.position;
        rigit = this.transform.GetComponent<Rigidbody> ();
        velo = rigit.velocity;
        // 元の位置に戻るための処理
        if (posi.y < -1.0 || (posi.z > 1 && velo == stay)) {
            rigit.velocity = stay;
            gameObject.transform.position = new Vector3(startx, 0.04f, 0.5f);
            posi = new Vector3(startx, 0.04f, 0.5f);
            throwJudge = false;
        }

        // 投げられた時の処理、投球数+1、スピードのテキスト表示
        if ((posi.x < -2 || posi.x > 2 || posi.z < -1.5 || posi.z > 1.5) && !throwJudge)
        {
            Script.PitchNow ++;
            throwJudge = true;
            Script.speed = velo.magnitude * 3.6f;
            Script.changeSpeed = true;
        }

        // 終了時
        if (Script.PanelCount == 9) Destroy(gameObject);
    }

    //衝突判定：パネルに当たったらそのパネルは消滅する
    void OnCollisionEnter(Collision collision)
    {
        float i = collision.impulse.magnitude / 15f;
        if (i > 1) i = 1;      
        GetComponent<AudioSource>().volume = i;
        ballsound.Play();
        
        if (collision.gameObject.tag == "Panel")
        {
            Destroy (collision.gameObject);
            Script.PanelCount++;
        }
    }
}
