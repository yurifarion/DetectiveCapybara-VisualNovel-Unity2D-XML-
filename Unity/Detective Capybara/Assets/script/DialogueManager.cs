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
		
		//Make all dialogues box disabled and just enable the one in the order
		foreach(GameObject p in dialogues){
			p.SetActive(false);
		}
    }
	public void ShowDialogue(){
		
		//Make all dialogues box disabled and just enable the one in the order
		foreach(GameObject p in dialogues){
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
		Debug.Log("dialogueOrder"+dialogueOrder+"dialoguesCount"+dialogues.Count);
        if(Input.GetMouseButtonDown(0) && dialogueOrder < dialogues.Count-1 ){
			dialogueOrder++;
			ShowDialogue();
		}
		
    }
}
