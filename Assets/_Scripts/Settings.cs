using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MenuState {

    public void VolumeChange(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
    }

    public void MusicChange(float value)
    {
        PlayerPrefs.SetFloat("Music", value);
    }

    public void SFXChange(float value)
    {
        PlayerPrefs.SetFloat("SFX", value);
    }
}
