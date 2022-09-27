using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    [SerializeField] private int fiveLettersSceneIndex;
    [SerializeField] private int categorySceneIndex;
    [SerializeField] private float loadingDelay = .7f;
    public event Action OnLevelLoadStarted;
    private LoadingAnimation animations;
    private Coroutine loadingRoutine;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        animations = GetComponent<LoadingAnimation>();
    }

    public void LoadLevel(bool isCategory)
    {
        if(loadingRoutine != null)
            return;
        
        loadingRoutine = StartCoroutine(AnimatedLevelLoading(isCategory ? categorySceneIndex : fiveLettersSceneIndex));

        if(!isCategory)
        {
            WordsManager.instance.SetRandomWord();
            CategoryManager.instance.SetRandomCategory();
        }
        
        PlayerDataControl.instance.RegisterGameStart(isCategory);
    }

    public void LoadMenu()
    {
        if(loadingRoutine != null)
            return;

        loadingRoutine = StartCoroutine(AnimatedLevelLoading(0));
    }

    IEnumerator AnimatedLevelLoading(int buildIndex)
    {
        animations.ShowCurtain();

        yield return new WaitForSeconds(loadingDelay);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

        OnLevelLoadStarted?.Invoke();

        animations.HideCurtain();
        
        yield return new WaitForSeconds(loadingDelay);
        
        loadingRoutine = null;
    }
}
