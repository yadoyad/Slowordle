using UnityEngine;
using TMPro;

public class HeaderControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI header;

    void Start()
    {
        ChangeHeader();
    }
    public void ChangeHeader()
    {
        header.text = WordsManager.instance.CategoryTitle;
    }
}
