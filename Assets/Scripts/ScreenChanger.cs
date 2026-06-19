using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChanger : MonoBehaviour
{
    // Declaration of variables for an integer and boolean
    // For Fullscreen changing
    private int intFullscreen;
    private bool boolFullscreen;
    // For Screen Resultion changing
    private int currentResolution;

    // Serialize dropdown and toggle game objects
    [SerializeField] TMP_Dropdown dropdownScreen;
    [SerializeField] Toggle toggleScreen;

    // The following are the names of the PlayerPrefs used in this script
    // "isFullscreen", "resolutionIndex"

    void Awake()
    {
        // Full Screen
        // Get the fullscreen PlayerPref with the default as not fullscreen
        // Sets the declared boolean to the corresponding integer value acquired
        intFullscreen = PlayerPrefs.GetInt("isFullscreen", 0);
        boolFullscreen = (intFullscreen == 1);

        // Change the toggle value based on the boolean
        toggleScreen.SetIsOnWithoutNotify(boolFullscreen);

        // Screen Resolution
        // Get the resolution PlayerPref with the default as 1920 x 1080
        currentResolution = PlayerPrefs.GetInt("resolutionIndex", (int)0);

        // Change the dropdown value based on the value
        dropdownScreen.SetValueWithoutNotify(currentResolution);
        // Change screen resolution and screen fullness
        SetResolution(currentResolution);
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        // Set the boolean to the toggle's value
        // This is needed to be updated since the SetResolution method requires the isFullScreen boolean as paramter
        // Finally, set the screen to full screen based on the boolean parameter
        boolFullscreen = isFullscreen;
        Screen.fullScreen = isFullscreen;

        // Convert the boolean to integer with 1 = true and 0 = false
        // Save the new toggle value as PlayerPrefs
        intFullscreen = (isFullscreen) ? 1 : 0;
        PlayerPrefs.SetInt("isFullscreen", (int)intFullscreen);
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        // Change screen resolution based on the dropdown index parameter
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
            // Fallback debugging
            default:
                Debug.LogError($"The index for the Dropdown is out of bounds, received the value of {resolutionIndex}");
                break;
        }

        // Save the new value as PlayerPrefs
        PlayerPrefs.SetInt("resolutionIndex", (int)resolutionIndex);
        PlayerPrefs.Save();
    }
}
