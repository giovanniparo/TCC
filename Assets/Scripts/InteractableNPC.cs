using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Interac");
            other.gameObject.GetComponent<Player>().OnInteractRange(true);
            EmoteManager.instance.Invoke(other.gameObject, EmoteType.EXCLAMA);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited interact");
            other.gameObject.GetComponent<Player>().OnInteractRange(false);
            EmoteManager.instance.ClearEmotes();
        }
    }
}
