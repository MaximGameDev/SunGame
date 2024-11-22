using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}