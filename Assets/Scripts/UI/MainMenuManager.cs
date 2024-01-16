using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject MainMenuButtons;

    public GameObject LevelSelectionButtons;

    public GameObject OptionButtons;

    public void OnSelectLevelPressed() {
        MainMenuButtons.SetActive(false);
        LevelSelectionButtons.SetActive(true);
    }

    public void OnBackButtonPressed() {
        MainMenuButtons.SetActive(true);
        LevelSelectionButtons.SetActive(false);
        OptionButtons.SetActive(false);
    }

    public void OnOptionsPressed() {
        OptionButtons.SetActive(true);
        MainMenuButtons.SetActive(false);
        
    }

    public void ExitGame() {
        Application.Quit();
    }
}
