using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBookManager : MonoBehaviour
{
    [SerializeField] private RecipeObject[] currentRecipes;
    [SerializeField] private GameObject recipeUIPrefab;

    private void Start()
    {
        Populate();
        transform.parent.gameObject.SetActive(false);
    }
    
    private void Populate()
    {
        for(int n = 0; n < currentRecipes.Length; n++)
        {
            GameObject recipeUI = Instantiate(recipeUIPrefab, transform.position, Quaternion.identity);
            recipeUI.transform.SetParent(this.transform);
            RecipeUI recipeUIscript = recipeUI.GetComponent<RecipeUI>();
            if (recipeUIscript)
            {
                recipeUIscript.Populate(currentRecipes[n].recipeSprite, currentRecipes[n].recipeName, currentRecipes[n].recipeTags);
            }
            else
            {
                Debug.LogError("Could not instantiate recipe object");
            }

        }
    }

    public void Show()
    {
        for(int n = 0; n < transform.childCount; n++)
        {
            transform.GetChild(n).gameObject.SetActive(!transform.GetChild(n).gameObject.activeSelf);
        }

        transform.parent.gameObject.SetActive(!transform.parent.gameObject.activeSelf);
    }
}
