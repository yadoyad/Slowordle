using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaunchManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> mainButtons = new List<GameObject>();
    [SerializeField] private GameObject firstLaunchPlayButton;
    [SerializeField] private GameObject confirmTutorialButton;
    [SerializeField] private GameObject dataAndAdsPanel;

    void Start()
    {
        StartCoroutine(FirstLaunchRoutine());
    }

    IEnumerator FirstLaunchRoutine()
    {
        yield return null;
        if(PlayerDataControl.instance.Data == null)
        {
            StartCoroutine(FirstLaunchRoutine());
        }
        else
        {
            FirstLaunchCheck();
        }
    }

    private void FirstLaunchCheck()
    {
        var playerData = PlayerDataControl.instance.Data;

        if(playerData.Total == 0)
        {
            dataAndAdsPanel.SetActive(true);
            
            foreach(var b in mainButtons)
            {
                b.SetActive(false);
            }

            firstLaunchPlayButton.SetActive(true);
            confirmTutorialButton.SetActive(true);
        }
        else
        {
            foreach(var b in mainButtons)
            {
                b.SetActive(true);
            }

            firstLaunchPlayButton.SetActive(false);
            confirmTutorialButton.SetActive(false);
        }
    }
}
