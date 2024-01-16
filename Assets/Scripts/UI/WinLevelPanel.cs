using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

[RequireComponent(typeof(AudioSource))]
public class WinLevelPanel : MonoBehaviour
{
    private string currentSceneLevel;
    private int nextLevelNumber;

    public AudioSource selectAudio;

    private void Start() {
        selectAudio.volume = PlayerPrefs.GetFloat("SoundVolume") / 20;

        currentSceneLevel = SceneManager.GetActiveScene().name;
        print(currentSceneLevel);
        print(currentSceneLevel.Replace("Level", "").Replace("Scene", ""));
        nextLevelNumber = Int32.Parse(currentSceneLevel.Replace("Level", "").Replace("Scene", "")) + 1;
    }

    public void Restart() {
        selectAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu() {
        selectAudio.Play();
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ToNextLevel() {
        selectAudio.Play();
        SceneManager.LoadScene("Scenes/Level" + nextLevelNumber.ToString() + "Scene");
    }
}
