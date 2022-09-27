using UnityEngine;
using System;

public class PlayerDataControl : MonoBehaviour
{
    public static PlayerDataControl instance;
    public PlayerData Data {get; private set;}
    public event Action OnPlayerDataLoaded;

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
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        Data = SaveAndLoad.instance.GetPlayerData();
        OnPlayerDataLoaded?.Invoke();
    }

    public void RegisterGameResult(int result)
    {
        if(Data == null)
            return;

        if(CategoryManager.instance.CurrectCategory == 3)
        {
            if(result == 1)
            {
                Data.Wins++;
                Data.WinStreak++;
            }
            else
                Data.WinStreak = 0;

            SavePlayerData(false);
        }
        else
            RegisterCategoryGameResult(CategoryManager.instance.CurrectCategory, result); 
    }

    private void RegisterCategoryGameResult(int categoryIndex, int result)
    {
        if(categoryIndex == 0)
            Data.Categories[0] = result; 
        else if(categoryIndex == 1)
            Data.Categories[1] = result; 
        else if(categoryIndex == 2)
            Data.Categories[2] = result; 
        else
            return;

        if(result == 1)
        {
            Data.Wins++;
            Data.WinStreak++;
        }
        else
            Data.WinStreak = 0;

        SavePlayerData(true);
    }

    public void RegisterGameStart(bool isCategory)
    {
        Data.Total++;
        SavePlayerData(isCategory);
    }

    private void SavePlayerData(bool isCategory)
    {
        if(Data != null)
            SaveAndLoad.instance.SavePlayerData(Data, isCategory);
    }
}
