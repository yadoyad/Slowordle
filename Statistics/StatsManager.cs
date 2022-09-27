using UnityEngine;

[RequireComponent(typeof(PlayerDataControl))]
public class StatsManager : MonoBehaviour
{
    [SerializeField] private PlayerDataControl playerDataControl;
    
    public int GetWinrate()
    {
        int result = 0;
        var total = playerDataControl.Data.Total;
        if(total > 0)
        {
            var wins = playerDataControl.Data.Wins;
            if(wins > 0)
            {
                float temp = ((float)wins / (float)total) * 100F;
                result = Mathf.FloorToInt(temp);
            }
        }
        return result;
    }

    public int GetCurrentStreak()
    {
        return playerDataControl.Data.WinStreak;
    }

    public int GetTotal()
    {
        return playerDataControl.Data.Total;
    }
}
