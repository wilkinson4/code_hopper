using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
	//public bool isStart;

    public void OnMouseUp()
	{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		
	}
}
