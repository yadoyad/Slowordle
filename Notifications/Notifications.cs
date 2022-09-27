using System.Collections;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    public static Notifications instance;
    [SerializeField] private GameObject popup;
    [SerializeField] private Animator popupAnimator;
    private Coroutine popupRoutine;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void ShowPopup(string message, float duration, bool stayForever)
    {
        if (popupRoutine != null)
            return;

        popupRoutine = StartCoroutine(ShowPopupRoutine(message, duration, stayForever));
    }

    IEnumerator ShowPopupRoutine(string message, float duration, bool stayForever = false)
    {
        popup.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = message;
        popupAnimator.SetTrigger("p_Show");
        yield return new WaitForSeconds(duration);
        popupAnimator.SetTrigger("p_Hide");
        popupRoutine = null;
    }
}
