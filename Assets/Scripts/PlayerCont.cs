using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = (new Vector3 (Mathf.Clamp (gameObject.transform.position.x, -1.5f, 1.5f),
               transform.position.y, Mathf.Clamp (gameObject.transform.position.z, -1.0f, 1.0f)));

    }
}
