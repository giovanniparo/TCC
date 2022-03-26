using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    [SerializeField] private Dialogbox dialogBoxScript;
    [SerializeField] private SelectMenu selectMenuScript;

    [SerializeField] private TextMeshProUGUI dialogBoxUIText;
    [SerializeField] private Image characterPortraitImage;
    [SerializeField] private TextMeshProUGUI characterNameUIText;

    private string m_dialog = null;
    private Sprite m_characterSprite = null;
    private string m_characterName = null;

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
    
    public void InitializeDialog(DialogObject dialog, int currentDialogPhrase)
    {
        m_dialog = dialog.phrases[currentDialogPhrase];
        m_characterName = dialog.talkingCharacter.characterName;
        m_characterSprite = dialog.talkingCharacter.chracterPortrait;
    }

    public void DisplayDialogBox()
    {
        Debug.Log("Displaying dialog box...");
        if (m_dialog != null && m_characterName != null && m_characterSprite != null)
        {
            dialogBoxScript.Show();
            dialogBoxUIText.text = m_dialog;
            characterPortraitImage.sprite = m_characterSprite;
            characterNameUIText.text = m_characterName;
        }
    }

    public void HideDialogBox()
    {
        dialogBoxUIText.text = null;
        characterPortraitImage.sprite = null;
        characterNameUIText.text = null;
        dialogBoxScript.Hide();
    }

    public void DisplaySelectMenu()
    {
        if(selectMenuScript != null)
        {
            selectMenuScript.Toggle();
        }
    }
}
