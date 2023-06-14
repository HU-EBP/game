using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsScreen : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;
    public Button applyButton;
    public TMP_Text resolutionLabel; 

    public AudioMixer theMixer;
    public TMP_Text mastLabel, musicLabel, sfxLabel;
    public Slider mastSlider, musicSlider, sfxSlider;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;

    private bool initialFullScreenState;
    private int initialVSyncCount;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial fullscreen and vsync states
        initialFullScreenState = Screen.fullScreen;
        initialVSyncCount = QualitySettings.vSyncCount;

        fullscreenTog.isOn = initialFullScreenState;
        vsyncTog.isOn = initialVSyncCount != 0;

        // Show the "Apply" button initially
        applyButton.gameObject.SetActive(true);

        // Set the initial resolution label
        UpdateResLabel();

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }
        if(!foundRes)
        {
            // Add the current resolution to the list
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;

            UpdateResLabel();
        }

        float vol = 0f;
        theMixer.GetFloat("MasterVol", out vol);
        mastSlider.value = vol;

        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;

        theMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;

        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 90).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 90).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 90).ToString();
    }

    void Update()
    {
        // Update the resolution label if the resolution changes
        if (Screen.width != resolutions[selectedResolution].horizontal || Screen.height != resolutions[selectedResolution].vertical)
        {
            UpdateResLabel();
        }
    }

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        // Apply the new graphics settings
        // Screen.fullScreen = fullscreenTog.isOn;

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        // Update the initial fullscreen and vsync states to match the new settings
        initialFullScreenState = Screen.fullScreen;
        initialVSyncCount = QualitySettings.vSyncCount;

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 90).ToString();

        theMixer.SetFloat("MasterVol", mastSlider.value);

        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }

    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 90).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 90).ToString();

        theMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

  
}

[System.Serializable]
public class ResItem 
{
    public int horizontal, vertical;
}
