using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    [SerializeField] private Dialogbox dialogBoxScript;
    [SerializeField] private TextMeshProUGUI dialogBoxUIText;
    private string m_dialog = null;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of DialogManager present");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    
    public void InitializeDialog(DialogObject dialog)
    {
        m_dialog = dialog.phrases[0];
    }

    public void Display()
    {
        if (m_dialog != null)
        {
            dialogBoxScript.ShowDialogbox();
            dialogBoxUIText.text = m_dialog;
        }
    }

    public void Clear()
    {
        
    }
}
