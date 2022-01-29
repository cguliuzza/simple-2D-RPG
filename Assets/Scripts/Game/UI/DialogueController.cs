using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : BaseSingletonBehaviour<DialogueController>
{
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textBody;
    public GameObject modal;

	public bool isOpen = false;

	private Queue<string> _sentences;
	private Animator _anim;

	// Use this for initialization
	void Start()
	{
		_sentences = new Queue<string>();
		_anim = GetComponent<Animator>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		isOpen = true;
		_anim.SetBool("IsOpen", true);

		if (dialogue.dialogueType == DialogueType.Chat)
			textName.text = dialogue.name;
		else
			textName.text = string.Empty;
		_sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			_sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (_sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = _sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		textBody.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			textBody.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		isOpen = false;
		_anim.SetBool("IsOpen", false);
	}
}
