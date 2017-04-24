using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Prompt[] prompts;
	private static List<Prompt> remainingPrompts;

	private Prompt currentPrompt;

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
	}
	
	// Update is called once per frame
	void Update () { }

	void SetCurrentPrompt() {
		// Get random number from 0 to remaningPrompts length
		int randomIndex = Random.Range(0, remainingPrompts.Count);

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
		// Correct answer (needs work)
		if (currentPrompt.answers.Contains(inputText.text)) {
			Debug.Log("Correct answer!" + inputText.text);
			// Find the term with that text
			
			// TODO: Make this better
			// Go through terms
			for (int i = 0; i < termsText.Count(); i++) {
				// If we found the right one
				if (termsText[i].text == inputText.text) {
					// Set color to black
					termsText[i].color = Color.black;
				}
			}
		} else {
			// Wrong answer
			Debug.Log("User input: " + inputText.text);
		}
	}
}
