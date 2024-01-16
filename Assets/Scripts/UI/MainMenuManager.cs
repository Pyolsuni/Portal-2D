using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMenuManager : MonoBehaviour
{

    public GameObject MainMenuSection;
    public GameObject LevelSelectionSection;
    public GameObject HowToPlaySection;
    public GameObject OptionSection;

    public AudioSource selectAudio;

    private void Start() {
        selectAudio.volume = PlayerPrefs.GetFloat("SoundVolume") / 20;
        //print("Volume: " + selectAudio.volume + "  " + PlayerPrefs.GetFloat("SoundVolume"));
    }
    public void OnSelectLevelPressed() {
        selectAudio.Play();
        MainMenuSection.SetActive(false);
        LevelSelectionSection.SetActive(true);
    }

    public void OnBackButtonPressed() {
        selectAudio.Play();
        MainMenuSection.SetActive(true);
        LevelSelectionSection.SetActive(false);
        HowToPlaySection.SetActive(false);
        OptionSection.SetActive(false);
    }

    public void OnHowToPlayPressed() {
        selectAudio.Play();
        HowToPlaySection.SetActive(true);
        MainMenuSection.SetActive(false);

    }
    public void OnOptionsPressed() {
        selectAudio.Play();
        OptionSection.SetActive(true);
        MainMenuSection.SetActive(false);
        
    }

    public void ExitGame() {
        Application.Quit();
    }
}
