using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SelectLevel : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    public AudioSource selectAudio;

    private void Start() {
        selectAudio.volume = PlayerPrefs.GetFloat("SoundVolume") / 20;
    }

    public void OnLevelSelectClicked() {
        selectAudio.Play();
        SceneManager.LoadScene("Scenes/Level" + levelText.text + "Scene");
    }

}
