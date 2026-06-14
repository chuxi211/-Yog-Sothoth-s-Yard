public class AddToEditorMenuEvent
{
    public string FoodID;
    public int Count;
    public AddToEditorMenuEvent(string FoodID,int count)
    {
        this.FoodID = FoodID;
        Count = count;
    }
}