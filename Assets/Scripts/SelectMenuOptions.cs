using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectMenuOptions : MonoBehaviour
{
    public UnityEvent optionType;

    public void Talk()
    {
        Debug.Log("Talking...");
    } 

    public void Buy()
    {
        Debug.Log("Buying....");
    }

    public void Leave()
    {
        Debug.Log("Leaving....");
    }
}
