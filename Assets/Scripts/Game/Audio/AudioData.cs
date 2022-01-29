using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    BGM, 
    SFX
}

public enum AudioIdentifier
{
    BGM_Main,
    BGM_Battle,
    Attack_Guard,
    Attack_Hit,
    Battle_Start,
    Button_Click,
    Item_Use,
    Item_Pickup
}

[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioData", order = 1)]
public class AudioData : ScriptableObject
{
    public AudioClip audioClip;
    public string audioName;
    public AudioType audioType;
    public AudioIdentifier audioIdentifier;
    public bool loop;
}
