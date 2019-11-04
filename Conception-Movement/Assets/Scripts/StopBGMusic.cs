using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBGMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	Destroy (GameObject.Find("Audio"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
