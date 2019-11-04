using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

	[SerializeField] private Image customImage;

    // Start is called before the first frame update
    void Start()
    {
		customImage.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.CompareTag("Player"))
    	{
    		customImage.enabled = true;
    		StartCoroutine(Exit());
    	}
    }

    IEnumerator Exit()
    {
    	yield return new WaitForSeconds(5);
    	customImage.enabled = false;
   		SceneManager.LoadScene("Gestion");
    }
}
