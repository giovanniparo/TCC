using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Dialog")]
public class DialogObject : ScriptableObject
{
    public string[] phrases;
    public CharacterObject talkingCharacter;
}
