using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	private string text = "";
	[SerializeField]
	Text textField;
	public string TextField
	{
		get {return text;}
	}

	void Start () {
		if(textField == null)
		{
			Debug.LogError("no textField");
		}
	}
	
	public void updateText(string text)
	{
		this.text = text;
	}
	public void clearText(){
		text = "";
	}
	// Update is called once per frame
	void Update () 
	{
		textField.text = text;
	}

}
