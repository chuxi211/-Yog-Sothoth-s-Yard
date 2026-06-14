using Command.Management;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDetailContainer : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private Image Frame;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Quantity;
    [SerializeField] private TextMeshProUGUI Price;
    [SerializeField] private Button Cooking;
    [SerializeField] private CanvasGroup CanvasGroup;
    [SerializeField] private Sprite[] RarityFrame;
    private Recipe Recipe;
    private CommandInvoker Invoker;
    public void BindInvoker(CommandInvoker invoker)
    {
        Invoker = invoker;
    }
    private void Awake()
    {
        Cooking.onClick.AddListener(StartCooking);
    }
    private void OnEnable()
    {
        EventBus.Subscribe<RecipeDetailEvent>(IsRecipeNull);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<RecipeDetailEvent>(IsRecipeNull);
    }
    private void OnDestroy()
    {
        Cooking.onClick.RemoveListener(StartCooking);
    }
    private void StartCooking()
    {
        Invoker.Execute(new StartCookingCommand(Recipe));
    }
    private void IsRecipeNull(RecipeDetailEvent e)
    {
        if (e.Recipe == null)
        {
            CanvasGroup.alpha = 0f;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
            Cooking.interactable = false;
        }
        if (e.Recipe != null)
        {
            CanvasGroup.alpha = 1f;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
            Cooking.interactable = true;
            Refresh(e.Recipe);
        }
    }
    private void Refresh(Recipe recipe)
    {
        Recipe = recipe;
        Icon.sprite = recipe.Output.Item.Icon;
        Frame.sprite = RarityFrame[recipe.Output.Item.Level-1];
        Name.text = recipe.Output.Item.Name;
        Price.text = recipe.Output.Item.Price.ToString();
    }
}
