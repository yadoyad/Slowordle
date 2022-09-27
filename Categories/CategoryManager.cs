using System;
using UnityEngine;

public class CategoryManager : MonoBehaviour
{
    public static CategoryManager instance;
    public event Action OnCategoriesSetUp;
    public Category[] Categories {get; private set;} = new Category[3];
    //0-1-2 нормальные категории, 3 - случайное слово
    public int CurrectCategory {get; private set;} 
    
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        DBManager.instance.OnCategoriesLoaded += SetUpCategories;
    }

    void OnDisable()
    {
        DBManager.instance.OnCategoriesLoaded -= SetUpCategories;
    }

    public void SetUpCategories()
    {
        var categoriesHolder = DBManager.instance.TodayCategories;
        
        if(categoriesHolder.Count != 3)
            return;
        
        for(int i=0; i < categoriesHolder.Count; i++)
        {
            var rawCategory = categoriesHolder[i].Split('_');
            Categories[i] = GetCategoryFromRawData(rawCategory, i);
        }

        OnCategoriesSetUp?.Invoke();
    }

    private Category GetCategoryFromRawData(string[] rawCategory, int index)
    {
        var tempTitle = rawCategory[0];
        tempTitle = Char.ToUpper(tempTitle[0]) + tempTitle.Substring(1);

        var cat = new Category(tempTitle, rawCategory[1], 
            PlayerDataControl.instance.Data.Categories[index]);

        return cat;
    }

    public void SetCurrentCategory(Category category)
    {
        CurrectCategory = Array.IndexOf(Categories, category);
    }

    public void SetRandomCategory() => CurrectCategory = 3;
}
