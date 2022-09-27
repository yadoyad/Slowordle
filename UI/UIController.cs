using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseRowScreen;
    [SerializeField] private GameObject loseNoRowScreen;
    [SerializeField] private GameObject concedeScreen;
    [SerializeField] private Animator darkBackgroundAnimator;
    [SerializeField] private Image darkBackgroundImage;
    private WordboxPresentation wordboxCtrl;

    void Awake()
    {
        wordboxCtrl = FindObjectOfType<WordboxPresentation>();
    }

    void ShowDarkBG()
    {
        darkBackgroundAnimator.SetTrigger("dbg_Show");
        darkBackgroundImage.raycastTarget = true;
    }

    void HideDarkBG()
    {
        darkBackgroundAnimator.SetTrigger("dbg_Hide");
        darkBackgroundImage.raycastTarget = false;
    }

    public void ShowWinScreen()
    {
        ShowDarkBG();
        winScreen.SetActive(true);
    }

    public void ShowLoseRowScreen()
    {
        ShowDarkBG();
        loseRowScreen.SetActive(true);
    }

    public void ShowLoseNoRowScreen()
    {
        ShowDarkBG();
        loseNoRowScreen.SetActive(true);
    }

    public void B_HideConcedeScreen()
    {
        HideDarkBG();
        concedeScreen.SetActive(false);
    }

    public void B_ConfirmConcede()
    {
        PlayerDataControl.instance.RegisterGameResult(2);

        concedeScreen.SetActive(false);
        loseRowScreen.SetActive(false);
        loseNoRowScreen.SetActive(true);
    }

    public void B_HideLoseRowScreen()
    {
        AdsControl.instance.ShowRewarded();

        wordboxCtrl.AddRow();
        
        HideDarkBG();
        loseRowScreen.SetActive(false);
    }

    public void B_LoadMenu()
    {
        LevelLoader.instance.LoadMenu();
    }

    public void B_LoadNextRandomWord()
    {
        LevelLoader.instance.LoadLevel(false);
    }

    public void B_Home()
    {
        ShowDarkBG();
        concedeScreen.SetActive(true);
    }
}
