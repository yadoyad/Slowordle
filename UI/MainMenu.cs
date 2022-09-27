using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons = new Button[3];
    [SerializeField] private TextMeshProUGUI total;
    [SerializeField] private TextMeshProUGUI winrate;
    [SerializeField] private TextMeshProUGUI winStreak;
    private DateTime lastBackbuttonClick;
    private TimeSpan backButtonTimespan = TimeSpan.FromSeconds(2);
    private MainMenu_Animations animations;
    
    void Start()
    {
        InitialSetup();
        animations = GetComponent<MainMenu_Animations>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            OnBackPressed();
    }

    void OnDisable()
    {
        CategoryManager.instance.OnCategoriesSetUp -= SetUpCategoryButtons;
        PlayerDataControl.instance.OnPlayerDataLoaded -= SetUpStats;
    }


    private void InitialSetup()
    {
        CategoryManager.instance.OnCategoriesSetUp += SetUpCategoryButtons;

        if(CategoryManager.instance.Categories[2] != null)
        {
            CategoryManager.instance.SetUpCategories();
        }

        if(PlayerDataControl.instance.Data != null)
            SetUpStats();
        else
            PlayerDataControl.instance.OnPlayerDataLoaded += SetUpStats;
    }

    private void OnBackPressed()
    {
        if(DateTime.Now - lastBackbuttonClick > backButtonTimespan)
        {
            Notifications.instance.ShowPopup
                ("Нажми еще раз чтобы выйти из игры", 2f, false);

            lastBackbuttonClick = DateTime.Now;
        }
        else
        {
            Application.Quit();
        }
    }

    public void RandomWord()
    {
        LevelLoader.instance.LoadLevel(false);
    }

    private void SetUpCategoryButtons()
    {
        for(int i=0; i < buttons.Length; i++)
        {
            var currentCategory = CategoryManager.instance.Categories[i];
            if(currentCategory.State == 0)
            {
                var buttonText = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = currentCategory.Title;

                buttons[i].onClick.AddListener(currentCategory.Load);
            }
            else
            {
                var buttonText = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Обновится завтра";

                buttons[i].interactable = false;
            }
        }
    }

    private void SetUpStats()
    {
        var statsManager = FindObjectOfType<StatsManager>();

        total.text = statsManager.GetTotal().ToString();
        winrate.text = statsManager.GetWinrate().ToString() + "%";
        winStreak.text = statsManager.GetCurrentStreak().ToString();
    }

    public void B_Categories()
    {
        DBManager.instance.OnCategoriesLoaded += animations.CategoriesLoadedHandler;
        DBManager.instance.CallGetTodayCategories();
    }
}
