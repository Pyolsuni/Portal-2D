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
    void Start()
    {
        sounds = FindObjectsOfType<AudioSource>();

        sliderText.text = soundSlider.value.ToString("0.00");
        soundSlider.onValueChanged.AddListener((value) => {
            sliderText.text = value.ToString("0.00");

            foreach (AudioSource source in sounds) {
                source.volume = Mathf.Log10(value);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
