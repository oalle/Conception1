using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static BackGroundMusic instance = null;
    public static BackGroundMusic Instance
    {
    	get {	return instance;	}
    }

    void Awake()
    {
    	if (instance != null && instance != this)
    	{
    		Destroy(this.gameObject);
    		return;
    	}
    	else
    	{
    		instance = this;
    	}
    	DontDestroyOnLoad(this.gameObject);
    	//SceneManager.sceneLoaded += OnSceneLoaded;
    }

void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode) {
       if (scene.name == "Game") {
             Destroy(this.gameObject);
             //Debug.Log("Inside the if to stop the DontDestroyOnLoad");
       }
 }

    // Update is called once per frame
    void Update()
    {
        
    }
}
