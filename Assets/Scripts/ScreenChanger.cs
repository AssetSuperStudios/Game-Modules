using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChanger : MonoBehaviour
{
    private int intFullscreen;
    private bool boolFullscreen;

    private int currentResolution;

    [SerializeField] TMP_Dropdown dropdownScreen;
    [SerializeField] Toggle toggleScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Full Screen
        // Default is not fullscreen
        intFullscreen = PlayerPrefs.GetInt("isFullscreen", 0);
        boolFullscreen = (intFullscreen == 1);

        toggleScreen.SetIsOnWithoutNotify(boolFullscreen);

        // Screen Resolution
        // Default is 1920 x 1080
        currentResolution = PlayerPrefs.GetInt("resolutionIndex", (int)0);

        dropdownScreen.SetValueWithoutNotify(currentResolution);
        // change screen resolution and screen fullness
        SetResolution(currentResolution);
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        boolFullscreen = isFullscreen;
        Screen.fullScreen = isFullscreen;

        intFullscreen = (isFullscreen) ? 1 : 0;
        PlayerPrefs.SetInt("isFullscreen", (int)intFullscreen);
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        switch (resolutionIndex)
        {
            // 16:9
            case 0:
                Screen.SetResolution(1920, 1080, boolFullscreen);
                break;
            // 8:5
            case 1:
                Screen.SetResolution(1440, 900, boolFullscreen);
                break;
            // 4:3
            case 2:
                Screen.SetResolution(800, 600, boolFullscreen);
                break;
        }

        PlayerPrefs.SetInt("resolutionIndex", (int)resolutionIndex);
        PlayerPrefs.Save();
    }
}
