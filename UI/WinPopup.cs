using UnityEngine;
using TMPro;

public class WinPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winstreak;
    [SerializeField] private TextMeshProUGUI winrate;

    void OnEnable()
    {
        var statsManager = FindObjectOfType<StatsManager>();
        winstreak.text = statsManager.GetCurrentStreak().ToString();
        winrate.text = statsManager.GetWinrate().ToString() + "%";
    }
}
