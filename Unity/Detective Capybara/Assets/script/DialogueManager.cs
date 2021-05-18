using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	public List<GameObject> dialogues = new List<GameObject>();//list of all dialogues this manager will deal with
	public List<DialogueSpeaker> speakers =  new List<DialogueSpeaker>();//list of all characters this manager will deal with
	private int dialogueOrder = 0;
	public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
		//create dialogue boxes
        GameObject n = Instantiate(prefab,transform.position,transform.rotation);
		n.GetComponent<DialogueBox>().Init("Wait I know you ...",speakers[0]);
		dialogues.Add(n);
		
		GameObject f = Instantiate(prefab,transform.position,transform.rotation);
		f.GetComponent<DialogueBox>().Init("I used to be an adverture like you",speakers[0]);
		dialogues.Add(f);
		
		GameObject g = Instantiate(prefab,transform.position,transform.rotation);
		g.GetComponent<DialogueBox>().Init("WTF !!?? stop it, i dont know you",speakers[1]);
		dialogues.Add(g);
		
		GameObject h = Instantiate(prefab,transform.position,transform.rotation);
		h.GetComponent<DialogueBox>().Init("better be leaving to be honest",speakers[1]);
		dialogues.Add(h);
		
		GameObject i = Instantiate(prefab,transform.position,transform.rotation);
		i.GetComponent<DialogueBox>().Init("Wait !!!",speakers[0]);
		dialogues.Add(i);
		
		//Make all dialogues box disabled and just enable the one in the order
		foreach(GameObject p in dialogues){
			p.SetActive(false);
		}
    }
	public void ShowDialogue(){
		
		//Make all dialogues box disabled and just enable the one in the order
		foreach(GameObject p in dialogues){
			//if the character is not going to talk but it is on the scene, it will leave it
			if((dialogues[dialogueOrder].GetComponent<DialogueBox>().speaker != p.GetComponent<DialogueBox>().speaker) && p.GetComponent<DialogueBox>().speaker.onScene){
				p.GetComponent<DialogueBox>().speaker.leaveScene = true;
			}
			p.SetActive(false);
		}
		if(dialogues[dialogueOrder].GetComponent<DialogueBox>().speaker.onScene){
			dialogues[dialogueOrder].SetActive(true);
			dialogues[dialogueOrder].GetComponent<DialogueBox>().Reposition();
		}
		
	}
    // Update is called once per frame
    void Update()
    {
		// if the character is going to talk and it'nt on scene it enters on scene
		if(dialogues[dialogueOrder].GetComponent<DialogueBox>().speaker.onScene == false){
			dialogues[dialogueOrder].GetComponent<DialogueBox>().speaker.enterScene = true;
		}
        if(Input.GetMouseButtonDown(0) && dialogueOrder < dialogues.Count-1 ){
			dialogueOrder++;
			ShowDialogue();
		}
		
    }
}
