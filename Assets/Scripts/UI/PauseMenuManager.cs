using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PausePanel;
    public GameObject OptionsPanel;

    private PostProcessVolume ppVolume;

    private bool isPaused = false;

    private void Start() {
        ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        ppVolume.enabled = false;
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                Pause();
            } else {
                Unpause();
            }
        }
    }

    private void Pause() {
        ppVolume.enabled = !ppVolume.enabled;
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        isPaused = !isPaused;
    }
    private void Unpause() {
        ppVolume.enabled = !ppVolume.enabled;
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        isPaused = !isPaused;
    }

    public void OnContinuePressed() {
        Unpause();
    }

    public void OnOptionsPressed() {
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void OnMainMenuPressed() {
        Unpause();
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void OnQuitPressed() {
        Application.Quit();
    }

    public void OnSavePressed() {
        PausePanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }
}

