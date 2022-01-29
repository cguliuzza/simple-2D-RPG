using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueType
{
    Chat,
    Notice
}

public enum TextAlignment
{
    Left,
    Center,
    Right
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue", order = 2)]
public class Dialogue : ScriptableObject
{
    public DialogueType dialogueType;
    public TextAlignment textAlignment;
    public string speakerName = "";
    public string description = "";

    [TextArea(3, 10)]
    public List<string> sentences = new List<string>();
}
