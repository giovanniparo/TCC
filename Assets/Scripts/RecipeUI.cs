using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private TextMeshProUGUI[] recipeTagsText;
    [SerializeField] private Image recipeImage;

    public void Populate(Sprite sprite, string recipeName, string[] recipeTags)
    {
        if(recipeTags.Length != recipeTagsText.Length)
        {
            Debug.LogWarning("Error trying to populate recipeTags");
            return;
        }

        recipeImage.sprite = sprite;
        recipeNameText.text = recipeName;
        for(int n = 0; n < recipeTags.Length; n++)
        {
            recipeTagsText[n].text = recipeTags[n];
        }

        this.gameObject.SetActive(false);
    }
}
