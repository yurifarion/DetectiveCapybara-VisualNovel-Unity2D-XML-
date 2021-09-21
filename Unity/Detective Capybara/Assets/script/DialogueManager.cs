using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

	
	public List<GameObject> dialogues = new List<GameObject>();//list of all dialogues this manager will deal with
	public List<DialogueSpeaker> speakers =  new List<DialogueSpeaker>();//list of all characters this manager will deal with
	private int dialogueOrder = 0;
	public GameObject loader;//gameobject created in the loading scene that have all XML data
	public GameObject prefab;//prefab of the chatbox
    // Start is called before the first frame update
    void Start()
    {
		loader = GameObject.FindGameObjectWithTag("Loader");//find the gameobject using its tag of Loader
		//create dialogue boxes using the loader data
		foreach(XMLData data_xml in loader.GetComponent<Loader>().data){
			GameObject n = Instantiate(prefab,transform.position,transform.rotation);
			int speakerID = pickCharacterID(data_xml.charText); // based on the name of the character picks the right ID
			n.GetComponent<DialogueBox>().Init(data_xml.dialogueText,speakers[speakerID]);
			dialogues.Add(n);
		}
       
		//Make all dialogues box disabled and just enable the one in the order
		foreach(GameObject p in dialogues){
			p.SetActive(false);
		}
    }
	//translate the name in the DATAXML in the a integer ID
	private int pickCharacterID(string name){
		switch(name){
			case "Capybara":
				return 0;
				break;
			case "Duck":
				return 1;
				break;
			default:
				return 0;
				break;
		}
	}
	// show the right dialogue depending on the order of the chat
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
