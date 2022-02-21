using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogbox : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowDialogbox()
    {
        
        this.gameObject.SetActive(true);
    }
}
