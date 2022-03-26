using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private GameObject selector;
    [SerializeField] private GameObject[] options;
    [SerializeField] private float selectorOffset;

    private int current = 0;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void Toggle()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    private void Update()
    {
        ProcessInput();
        SetSelector();
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && current > 0)
        {
            current--;
        }
        else if(Input.GetKeyDown(KeyCode.S) && current < options.Length - 1)
        {
            current++;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            options[current].GetComponent<SelectMenuOptions>()?.optionType.Invoke();
        }
    }

    private void SetSelector()
    {
        selector.transform.position = new Vector3(options[current].transform.position.x - selectorOffset,
                                                  options[current].transform.position.y,
                                                  options[current].transform.position.z);
    }
}
