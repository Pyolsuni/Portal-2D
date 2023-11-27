using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class WinLevelPanel : MonoBehaviour
{
    private string currentSceneLevel;
    private int nextLevelNumber;

    private void Start() {
        currentSceneLevel = SceneManager.GetActiveScene().name;
        print(currentSceneLevel);
        print(currentSceneLevel.Replace("Level", "").Replace("Scene", ""));
        nextLevelNumber = Int32.Parse(currentSceneLevel.Replace("Level", "").Replace("Scene", "")) + 1;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu() {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ToNextLevel() {
        SceneManager.LoadScene("Scenes/Level" + nextLevelNumber.ToString() + "Scene");
    }
}
