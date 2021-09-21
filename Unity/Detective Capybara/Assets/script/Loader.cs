using UnityEngine;

using System.Collections;

using System.Collections.Generic; //Needed for Lists

using System.Xml; //Needed for XML functionality

using System.Xml.Serialization; //Needed for XML Functionality

using System.IO;

using System.Xml.Linq; //Needed for XDocument

using UnityEngine.SceneManagement;//Used to manage the scenes in the class

public class Loader : MonoBehaviour {

	public XDocument xmlDoc; //create Xdocument. Will be used later to read XML file 
	public IEnumerable<XElement> items; //Create an Ienumerable list. Will be used to store XML Items. 
	public List <XMLData> data = new List <XMLData>(); //Initialize List of XMLData objects.

	public int iteration = 0, pageNum = 0;

	public string charText, dialogueText;

	public bool finishedLoading = false;

	void Start (){

		DontDestroyOnLoad (gameObject); //Allows Loader to carry over into new scene 
		LoadXML (); //Loads XML File. Code below. 
		StartCoroutine ("AssignData"); //Starts assigning XML data to data List. Code below
		
	}
	void LoadXML(){
		
		//Assigning Xdocument xmlDoc. Loads the xml file from the file path listed. 
		xmlDoc = XDocument.Load( "Assets/XML Files/dialogues.xml" );

		//This basically breaks down the XML Document into XML Elements. Used later. 
		items = xmlDoc.Descendants("page").Elements ();
		

	}
	//this is our coroutine that will actually read and assign the XML data to our List 
	IEnumerator AssignData(){
		
		/*foreach allows us to look at every Element of our XML file and do something with each one. Basically, this line is saying “for each element in the xml document, do something.
		*/ 
		foreach (var item in items){
		
			/*Determine if the <page number> attribute in the XML is equal to whatever our current iteration of the loop is. If it is, then we want to assign our variables to the value of the XML Element that we need.

			*/
			if(item.Parent.Attribute("number").Value == iteration.ToString ()){
					
				pageNum = int.Parse (item.Parent.Attribute ("number").Value); 
				charText = item.Parent.Element("name").Value.Trim(); 
				dialogueText = item.Parent.Element ("dialogue").Value.Trim();
				/*Create a new Index in the List, which will be a new XMLData object and pass the previously assigned variables as arguments so they get assigned to the new object’s variables.

				*/
				data.Add (new XMLData(pageNum, charText, dialogueText));
				/*To test and make sure the data has been applied to properly, print out the musicClip name from the data list’s current index. This will let us know if the objects in the list have been created successfully and if their variables have been assigned the right values.
				*/
				
				//Debug.Log (dialogueText);
				iteration++; //increment the iteration by 1
			}
			
			
		}
	Scene scene = SceneManager.GetActiveScene();//pick the current scene
	if(scene.name != "SampleScene") SceneManager.LoadScene("SampleScene");//if it'snt already sample scene then load it
	finishedLoading = true; //tell the program that we’ve finished loading data. yield return null;
	yield return 0;
	}

}
	

	// This class is used to assign our XML Data to objects in a list so we can call on them later. 
	public class XMLData {

	public int pageNum;

	public string charText, dialogueText;

	// Create a constructor that will accept multiple arguments that can be assigned to our variables. 
	public XMLData (int page, string character, string dialogue)
	{
		pageNum = page;
		charText = character;
		dialogueText = dialogue;
	}

}
