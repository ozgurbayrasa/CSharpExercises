namespace CookieCookbook.App
{
    public interface IFileOperation
    {
        public void SaveRecipe(string path);
        public void LoadRecipe();
    }
}