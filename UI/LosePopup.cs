using UnityEngine;
using TMPro;

public class LosePopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] answer = new TextMeshProUGUI[5];
    
    void OnEnable()
    {
        var correctWord = WordsManager.instance.CorrectWord;
        for(int i=0; i < answer.Length; i++)
        {
            answer[i].text = correctWord[i].ToString();
        }
    }
}
