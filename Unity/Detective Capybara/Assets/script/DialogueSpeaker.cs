using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : MonoBehaviour
{
	public string name;
	public Sprite capybara_Char; //Graphics of Capybara
	public Sprite duck_Char; //Graphics of duck
	public bool flip_X = false;//which position the speaker is
	public bool onScene = false;//the character is already on the scene ?
	public bool enterScene = false;// variable that controls if character is enter the scene
	public bool leaveScene = false;// variable that controls if character is leaving the scene
    private float speedOfMovement = 20f;//speed of which the character enter and leave the scene
	private GameManager gm;
	private DialogueManager dm;
	
	
	void Start(){
		
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		dm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueManager>();
		SelectChar();
		
		if(flip_X){
			transform.position = gm.startPosition_right.position;//transport player to the left start point
			GetComponent<SpriteRenderer>().flipX = true; // if this char is flipped flip the render
		}
	}
	//This moves the sprite of the character to the speaking position
	void EnterChat(){
		if(!onScene){
			Transform Destination;
			if(!flip_X) Destination = gm.speakerPosition_left;
			else  Destination = gm.speakerPosition_right;
			
			float step = speedOfMovement * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Destination.position, step);
			if(transform.position == Destination.position){
				onScene = true;
				enterScene = false;
				dm.ShowDialogue();
			}
		}
	}
	//change the char graphics depending on the name
	void SelectChar(){
		if(name == "Capybara"){
			GetComponent<SpriteRenderer>().sprite = capybara_Char;
		}
		else if(name == "Duck"){
			GetComponent<SpriteRenderer>().sprite = duck_Char;
		}
	}
	// this moves back the character to listening position
	void LeaveChat(){
		if(onScene){
			Transform Destination;
			if(!flip_X) Destination = gm.startPosition_left;
			else  Destination = gm.startPosition_right;
			
			float step = speedOfMovement * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Destination.position, step);
			if(transform.position == Destination.position){
				onScene = false;
				leaveScene = false;
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
		if(enterScene){
			EnterChat();
		}
		else if(leaveScene){
			LeaveChat();
		}
	}
}
