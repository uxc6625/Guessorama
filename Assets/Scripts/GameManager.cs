using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Prompt[] prompts;
    public GameObject Notification;
	private static List<Prompt> remainingPrompts;

    //public Vector2 startinPos, endPos, size;
    public static Vector2 startingPosition;
    public static Vector2 wantedPosition;
    private static Vector3 velocity3 = Vector3.zero;
    private Prompt currentPrompt;
    //private float speed = 1.1f;



    // Stores the value of the prompt
    [SerializeField]
	private Text promptText;

	// Stores the value of the input
	[SerializeField]
	private Text inputText;

	// Stores the value of an answer
	[SerializeField]
	private Text[] termsText;

	// Use this for initialization
	void Start () {
		// Start
		if (remainingPrompts == null || remainingPrompts.Count == 0) {
			// Load remainingPrompts to prompts
			remainingPrompts = prompts.ToList<Prompt>();
		}

		SetCurrentPrompt();
        Notification.SetActive(false);
        startingPosition = Notification.transform.position;
        wantedPosition = new Vector2 (Notification.transform.position.x,Notification.transform.position.y + 100);
    }
	
	// Update is called once per frame
	void Update () { }

	void SetCurrentPrompt() {
		// Get random number from 0 to remaningPrompts length
		int randomIndex = UnityEngine.Random.Range(0, remainingPrompts.Count);

		// Set currentPrompt using the random index
		currentPrompt = remainingPrompts[randomIndex];
		promptText.text = currentPrompt.prompt;
		int promptAnswersCount = currentPrompt.answers.Count();

		for (int i = 0; i < promptAnswersCount; i++) {
			// Set text of boxes
			termsText[i].text = currentPrompt.answers[i];
			termsText[i].color = Color.clear;
		}

		// Remove prompt from list
		remainingPrompts.RemoveAt(randomIndex);
	}

	public void UserEnteredWord() {
		// If the input test is and answer we'll get the index in the array
		// Otherwise we get -1
		int index = Array.IndexOf(currentPrompt.answers, inputText.text);
		
		// Correct answer (needs work) - This could also be index >= 0
		if (currentPrompt.answers.Contains(inputText.text)) {


            //float step = speed * Time.deltaTime;
            Notification.SetActive(true);
            //Notification.transform.position = new Vector2(Notification.transform.position.x,Notification.transform.position.y + 100);
            Notification.transform.position = Vector2.Lerp(Notification.transform.position, wantedPosition,100);
            //Notification.transform.position = Vector3.SmoothDamp(startingPosition,wantedPosition, ref velocity, 0.3F);
            //Notification.transform.position = Vector3.MoveTowards(wantedPosition, startingPosition, step);
            //Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x + 50,Camera.main.transform.position.y);

            //Notification.transform.position = Vector3.SmoothDamp(wantedPosition, startingPosition, ref velocity3, 2);
            StartCoroutine(Timer());
            


            //Notification.transform.position = Vector3.SmoothDamp(startingPosition, startingPosition, ref velocity3, 0.35f);
            //Notification.transform.position = Vector3.SmoothDamp(startingPosition, wantedPosition, ref velocity3, 0.35f);

            Debug.Log("Correct answer!" + inputText.text);
			// Set the color of the text in the box black	
			termsText[index].color = Color.black;
		} else {
			// Wrong answer
			Debug.Log("User input: " + inputText.text);
		}
	}

    IEnumerator Timer()
    {
        
        yield return new WaitForSecondsRealtime(3);

        Notification.SetActive(false);
        Notification.transform.position = new Vector2(Notification.transform.position.x, Notification.transform.position.y - 100);
    }
}
