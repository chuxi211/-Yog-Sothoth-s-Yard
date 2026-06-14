using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeContainer : MonoBehaviour
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private Image RarityFrame;
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private List<Sprite> Rarity;
    [SerializeField]
    private Button ShowDetail;
    private Recipe Recipe;
    private void Awake()
    {
        ShowDetail.onClick.AddListener(PublishRecipeInfo);
    }
    private void OnDestroy()
    {
        ShowDetail.onClick.RemoveListener(PublishRecipeInfo);
    }
    public void BindRecipe(Recipe recipe)
    {
        if (recipe == null) { Debug.LogError("recipe is null"); return; }
        Recipe = recipe;
    }
    public void Refresh()
    {
        if (Recipe == null) { Debug.LogError("Recipe is null"); return; }
        Icon.sprite = Recipe.Output.Item.Icon;
        RarityFrame.sprite = Rarity[Recipe.Output.Item.Level-1];
        Name.text = Recipe.Output.Item.Name;
    }
    private void PublishRecipeInfo()
    {
        EventBus.Publish(new RecipeDetailEvent(Recipe));
        Debug.Log($"Publish Event:"+nameof(RecipeDetailEvent));
    }
}
