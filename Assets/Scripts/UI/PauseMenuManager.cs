using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PauseMenu : MonoBehaviour {

    public GameObject PausePanel;
    public GameObject OptionsPanel;

    private bool isPaused = false;

    private PostProcessVolume ppVolume;

    public AudioSource selectAudio;


    private void Start() {
        ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        ppVolume.enabled = false;

        selectAudio.volume = PlayerPrefs.GetFloat("SoundVolume") / 20;
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
        selectAudio.Play();
        Unpause();
    }

    public void OnOptionsPressed() {
        selectAudio.Play();
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void OnRestartLevelPressed() {
        selectAudio.Play();
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenuPressed() {
        selectAudio.Play();
        Unpause();
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void OnQuitPressed() {
        selectAudio.Play();
        Application.Quit();
    }

    public void OnSavePressed() {
        selectAudio.Play();
        PausePanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }
}

