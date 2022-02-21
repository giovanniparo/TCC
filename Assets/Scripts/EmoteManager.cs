using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmoteType
{
    EXCLAMA,
    INTER
}

public class EmoteManager : MonoBehaviour
{
    public static EmoteManager instance;

    [SerializeField] private GameObject emoteExclamaPrefab;

    private List<GameObject> instantiatedEmotes = new List<GameObject>();

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one instance of EmoteManager present");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Invoke(GameObject target, EmoteType type)
    {
        if(target == null)
        {
            Debug.LogError("Tried to invoke a emote in a null object");
            return;
        }

        for(int n = 0; n < target.transform.childCount; n++)
        {
            if (target.transform.GetChild(n).CompareTag("EmotePosition"))
            {
                Transform emotePos = target.transform.GetChild(n).transform;

                InstantiateEmote(emotePos, type);

                return;
            }
        }
    }

    public void InstantiateEmote(Transform emotePosition, EmoteType type)
    {
        GameObject emote = null;

        switch (type)
        {
            case EmoteType.EXCLAMA:
                emote = Instantiate(emoteExclamaPrefab, emotePosition.position, Quaternion.identity);
                break;
            default:
                Debug.LogError("Tried to invoke a non-defined emote type");
                break;
        }

        if(emote != null)
        {
            instantiatedEmotes.Add(emote);
            emote.transform.parent = emotePosition.gameObject.transform;
        }
        else
        {
            Debug.LogError("The emote was not instantiated correctly");
        }
    }

    public void ClearEmotes()
    {
        foreach(GameObject emote in instantiatedEmotes)
        {
            Destroy(emote);
        }

        instantiatedEmotes.Clear();
    }
}