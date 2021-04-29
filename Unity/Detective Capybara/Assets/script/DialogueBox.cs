using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
	private Image dialogueBox_bg;
	private Text dialogueText;
	private string message;
	private bool isTextComplete = false;
	public float typeInterval = 0.02f;
	public string Speaker = "None";//the character responsable for the lines
	private bool flip_X = false;//Indicates if the speaker is on left or right, by defaul flip_x false is pointing left
	
	

	public void Init(string nameSpeaker,string msg,bool isFlip_x){
		Speaker = nameSpeaker;
		flip_X = isFlip_x;
		// if the dialog box was created without text if picks from the GameObject
		if(msg == "")msg = dialogueText.text;
		message = msg;
		dialogueBox_bg = GetComponent<Image>();//get the image of the Chatbox from the gameobject
		dialogueText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();//get the Text component of the child
		StartCoroutine(type());
	}
	//type the message of the chatbox respecting the typeInterval
	IEnumerator type(){
		dialogueText.text = "";
		foreach(char letter in message.ToCharArray()){
			dialogueText.text += letter;
			yield return 0;
			yield return new WaitForSeconds(typeInterval);
		}
		isTextComplete = true;
	}
	
}
