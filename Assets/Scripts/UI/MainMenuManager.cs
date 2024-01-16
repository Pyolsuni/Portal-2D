using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject MainMenuSection;

    public GameObject LevelSelectionSection;

    public GameObject HowToPlaySection;

    public GameObject OptionSection;

    public void OnSelectLevelPressed() {
        MainMenuSection.SetActive(false);
        LevelSelectionSection.SetActive(true);
    }

    public void OnBackButtonPressed() {
        MainMenuSection.SetActive(true);
        LevelSelectionSection.SetActive(false);
        HowToPlaySection.SetActive(false);
        OptionSection.SetActive(false);
    }

    public void OnHowToPlayPressed() {
        HowToPlaySection.SetActive(true);
        MainMenuSection.SetActive(false);

    }
    public void OnOptionsPressed() {
        OptionSection.SetActive(true);
        MainMenuSection.SetActive(false);
        
    }

    public void ExitGame() {
        Application.Quit();
    }
}
