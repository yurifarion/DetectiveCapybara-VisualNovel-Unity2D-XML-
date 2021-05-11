using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
	private SpriteRenderer dialogueBox_bg;
	private TextMeshPro dialogueText;
	private bool isTextComplete = false;
	public DialogueSpeaker speaker;//the character responsable for the lines
	private bool flip_X = false;//Indicates if the speaker is on left or right, by defaul flip_x false is pointing left

	public void Init(string msg,DialogueSpeaker _speaker){
		speaker = _speaker;
		flip_X = _speaker.flip_X;
		
		if(flip_X)GetComponent<SpriteRenderer>().flipX = true; // if this char is flipped flip the render

		// if the dialog box was created without text if picks from the GameObject
		if(msg == "")msg = dialogueText.text;
		dialogueBox_bg = GetComponent<SpriteRenderer>();//get the image of the Chatbox from the gameobject
		dialogueText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();//get the Text component of the child
		dialogueText.text = msg;
	}
	public void Reposition(){
		
		//gets the position of the speaker to repositionate the chatbox depending on the side of the chat
		Vector3 chatBoxPosition = speaker.gameObject.transform.position;
		
		if(flip_X)chatBoxPosition.x -= 8;
		else chatBoxPosition.x += 8;
		
		transform.position = chatBoxPosition;
	}
	
}
