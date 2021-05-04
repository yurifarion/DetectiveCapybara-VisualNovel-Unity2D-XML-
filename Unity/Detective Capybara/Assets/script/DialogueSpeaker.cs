using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : MonoBehaviour
{
	public string name;
	public bool flip_X = false;//which position the speaker is
	public bool onScene = false;//the character is already on the scene ?
	public bool enterScene = false;// variable that controls if character is enter the scene
	public bool leaveScene = false;// variable that controls if character is leaving the scene
    private float speedOfMovement = 20f;//speed of which the character enter and leave the scene
	public Transform test;
	private GameManager gm;
	private DialogueManager dm;
	
	
	void Start(){
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		dm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueManager>();
	}
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
