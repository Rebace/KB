namespace KitchenBook.Domain;

public class Recipe
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CookingTime { get; private set; }
    public int Portions { get; private set; }
    public int Stars { get; private set; }
    public int Likes { get; private set; }

    // Workaround for EF
    protected Recipe()
    {
    }

    public Recipe(string title, string description, int cookingTime, int portions, int stars, int likes)
    {
        Title = title;
        Description = description;
        CookingTime = cookingTime;
        Portions = portions;
        Stars = stars;
        Likes = likes;
    }
}