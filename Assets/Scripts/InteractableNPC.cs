using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    private enum NPCStates
    {
        IDLE,
        TALKING,
        WAITING_INPUT
    }
    
    public float showDialogTime = 4.0f;
    public DialogObject[] npcDialogs;

    private int currentDialogCounter = 0;
    private int currentDialogPhraseCounter = 0;
    private NPCStates state = NPCStates.IDLE;
    private GameObject playerReference = null;
    private float timeCounter = 0.0f;

    private void Update()
    {
        if(state == NPCStates.TALKING)
        {
            timeCounter += Time.deltaTime;
            if(timeCounter >= showDialogTime)
            {
                DoneTalking();
            }
        }        
    }

    public void Interact()
    {
        if(state == NPCStates.IDLE) //Check if in IDLE state so that the player cannot spam click the interact button
        {
            state = NPCStates.TALKING;
            DialogManager.instance.InitializeDialog(npcDialogs[currentDialogCounter], currentDialogPhraseCounter);
            DialogManager.instance.DisplayDialogBox();

            /* Code to show input box on npcs
             * state = NPCStates.WAITING_INPUT;
             * DialogManager.instance.DisplaySelectMenu();
            */

            //Code to check which dialog counter should be incremented
            currentDialogPhraseCounter++;
            if(currentDialogPhraseCounter >= npcDialogs[currentDialogCounter].phrases.Length)
            {
                currentDialogPhraseCounter = 0;
                currentDialogCounter++;
                if(currentDialogCounter >= npcDialogs.Length)
                {
                    currentDialogCounter = 0;
                }
            }
        }
    }

    public void DoneTalking()
    {
        state = NPCStates.IDLE;
        timeCounter = 0.0f;
        DialogManager.instance.HideDialogBox();
        if(playerReference != null)
        {
            playerReference.GetComponent<Player>().SetPlayerBusy(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerReference = other.gameObject;
            Debug.Log("Player Interac w/ " + this.gameObject.name);
            playerReference.GetComponent<Player>().OnInteractRange(true, this);
            EmoteManager.instance.Invoke(other.gameObject, EmoteType.EXCLAMA);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited interact w/ " + this.gameObject.name);
            other.gameObject.GetComponent<Player>().OnInteractRange(false, this);
            EmoteManager.instance.ClearEmotes();
        }
    }
}
