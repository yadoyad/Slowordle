using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MainMenu_Animations : MonoBehaviour
{
    [SerializeField] private GameObject categoriesRefreshedImage;
    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ShowRefreshedImage();
    }

    public void ShowCategories()
    {
        animator.SetTrigger("ShowCats");
    }

    public void HideCategories()
    {
        animator.SetTrigger("HideCats");
    }

    public void ShowHowToPlay()
    {
        animator.SetTrigger("ShowHowToPlay");
    }

    public void HideHowToPlay()
    {
        animator.SetTrigger("HideHowToPlay");
    }

    public void CategoriesLoadedHandler()
    {
        ShowCategories();
        DBManager.instance.OnCategoriesLoaded -= CategoriesLoadedHandler;
    }

    public void ShowRefreshedImage()
    {
        categoriesRefreshedImage.SetActive(SaveAndLoad.instance.CheckIfItsFirstLaunchOfTheDay());
    }
}
