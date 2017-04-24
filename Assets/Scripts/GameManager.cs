using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
			Debug.Log("Correct answer!" + inputText.text);
			// Set the color of the text in the box black	
			termsText[index].color = Color.black;
		} else {
			// Wrong answer
			Debug.Log("User input: " + inputText.text);
		}
	}
}
