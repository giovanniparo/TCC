using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Recipe")]
public class RecipeObject : ScriptableObject
{
    public string recipeName;
    public Sprite recipeSprite;
    public string[] recipeTags;
}
