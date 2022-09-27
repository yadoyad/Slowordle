public class Category
{
    public string Title {get; private set;}
    public string Answer {get; private set;}
    //0 - не разгадана, 1 - разгадана, 2 - провалена
    public int State {get; private set;} = 0;

    public Category(string title, string answer, int state)
    {
        Title = title;
        Answer = answer;
        State = state;
    } 

    public void Load()
    {
        WordsManager.instance.SetCorrectWord(Answer, Title);
        LevelLoader.instance.LoadLevel(true);
        CategoryManager.instance.SetCurrentCategory(this);
    }
}
