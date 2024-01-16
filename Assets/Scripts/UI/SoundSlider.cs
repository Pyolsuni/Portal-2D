using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public Slider soundSlider;
    public TextMeshProUGUI sliderText;

    private AudioSource[] sounds;

    private void Awake() {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        sliderText.text = soundSlider.value.ToString("0.00");
    }
    void Start()
    {
        sounds = FindObjectsOfType<AudioSource>(true);

        soundSlider.onValueChanged.AddListener((value) => {
            sliderText.text = value.ToString("0.00");
            foreach (AudioSource source in sounds) {
                source.volume = Mathf.Log10(value);
            }
            PlayerPrefs.SetFloat("SoundVolume", value);
        });
    }
}
