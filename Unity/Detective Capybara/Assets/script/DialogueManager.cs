using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	public List<GameObject> dialogues = new List<GameObject>();//list of all dialogues this manager will deal with
	private int dialogueOrder = 0;
	public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
		//create dialogue boxes
        GameObject n = Instantiate(prefab,transform.position,transform.rotation);
		n.GetComponent<DialogueBox>().Init("Capybara","Wait I know you ...",false);
		n.transform.SetParent(GameObject.FindGameObjectWithTag("Canva").transform);// in order to the gameobject appear in the game it need to be a child of Canvas
		dialogues.Add(n);
		
		GameObject f = Instantiate(prefab,transform.position,transform.rotation);
		f.GetComponent<DialogueBox>().Init("Capybara","I used to be an adverture like you",false);
		f.transform.SetParent(GameObject.FindGameObjectWithTag("Canva").transform);
		dialogues.Add(f);
		
		ShowDialogue();
    }
	void ShowDialogue(){
		
		//Make all dialogues box disabled and just enable the one in the order
		foreach(GameObject p in dialogues){
			p.SetActive(false);
		}
		dialogues[dialogueOrder].SetActive(true);
	}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
			dialogueOrder++;
			//ShowDialogue();
		}
    }
}
