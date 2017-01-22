using UnityEngine;
using System.Collections;

public class RestartButtonController : MonoBehaviour {

	public void StartGame()
	{
		Application.LoadLevel("Title");
	}
}
	
