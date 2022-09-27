public class PlayerData
{
    public int[] Categories = new int[3];
    public int Total;
    public int Wins;
    public int WinStreak;

    public PlayerData(int cat_1, int cat_2, int cat_3, int total, int wins, int winStreak)
    {
        Categories[0] = cat_1;
        Categories[1] = cat_2;
        Categories[2] = cat_3;
        Total = total;
        Wins = wins;
        WinStreak = winStreak;
    }
}
