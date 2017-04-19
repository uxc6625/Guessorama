using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriviaGameManager : MonoBehaviour {

	public TriviaQuestion[] questions;

	// Will hold unanswered questions
	private static List<TriviaQuestion> unansweredQuestions;

	private TriviaQuestion currentQuestion;

	void Start() {
		// If no answered questions
		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			// Set list to questions using Linq helper method
			unansweredQuestions = questions.ToList<TriviaQuestion>();
		}

		GetRandomQuestion();
		Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
	}

	void GetRandomQuestion() {
		// Choose random number between 0 and unansweredQuestions length
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);

		// Set currentQuestion using random index
		currentQuestion = unansweredQuestions[randomQuestionIndex];

		// Remove from list - might not want this until after user has answered question
		unansweredQuestions.RemoveAt(randomQuestionIndex);
	}
}
