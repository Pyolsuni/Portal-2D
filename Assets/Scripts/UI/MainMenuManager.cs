using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject MainMenuButtons;

    public GameObject LevelSelectionButtons;

    public void OnSelectLevelPressed() {
        MainMenuButtons.SetActive(false);
        LevelSelectionButtons.SetActive(true);
    }

    public void OnBackButtonPressed() {
        MainMenuButtons.SetActive(true);
        LevelSelectionButtons.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
