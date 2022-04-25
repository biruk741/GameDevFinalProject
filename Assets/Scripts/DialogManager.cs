using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
	public TMPro.TMP_Text nameText;
	public TMPro.TMP_Text dialogueText;

	public Animator animator;

	private Queue<string> sentences = new Queue<string>();
	private Dialogue dialogue;
	public bool dialogueEnd;

	// Use this for initialization


	public void StartDialogue(Dialogue dialogue)
	{
		dialogueEnd = false;
		this.dialogue = dialogue;
		animator.SetBool("isOpen", true);

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		nameText.text = sentence[0].Equals('2') ? dialogue.character2Name:  dialogue.character1Name;
		StopAllCoroutines();
		print("sentence[0]==" + sentence[0] + " and sentence[0].Equals('1')== " + sentence[0].Equals("1"));
		StartCoroutine(TypeSentence(!sentence[0].Equals('1') && !sentence[0].Equals('2') ? sentence : sentence.Substring(1, sentence.Length - 1)));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.01f);
		}
	}

	void EndDialogue()
	{
		animator.SetBool("isOpen", false);
		dialogueEnd = true;
	}
}
