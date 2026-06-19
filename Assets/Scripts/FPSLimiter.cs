using TMPro;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    // Serialized dropdown
    [SerializeField] TMP_Dropdown dropdownFPS;
    // Integer variable declaration
    private int targetFPS;

    // The following are the names of the PlayerPrefs used in this script
    // "fpsIndex"
    
    // Load the player's preferred FPS value, with a default value for fallback
    // Set the FPS and the dropdown's value to the value
    void Awake()
    {

        // Default is case 4
        targetFPS = PlayerPrefs.GetInt("fpsIndex", (int)4);

        FpsChanger(targetFPS);
        dropdownFPS.SetValueWithoutNotify(targetFPS);
    }

    // Accepts an integer parameter
    // With the current dropdown, it only has values of 0 to 4
    // Added default in for fallback
    public void FpsChanger(int dropdownIndex)
    {
        switch (dropdownIndex)
        {
            // vSync: Off, FPS: 30
            case 0:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 30;
                break;
            // vSync: Off, FPS: 60
            case 1:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 60;
                break;
            // vSync: Off, FPS: 120
            case 2:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 120;
                break;
            // vSync: Off, FPS: Unlimited, aka depends on the user's natural frame rate
            case 3:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = -1;
                break;
            // vSync: On, FPS: Unlimited, aka depends on the user's vSync
            case 4:
                QualitySettings.vSyncCount = 1;
                Application.targetFrameRate = -1;
                break;
            // Index out of bounds
            default:
                Debug.LogError($"The index for the Dropdown is out of bounds, received the value of {dropdownIndex}");
                break;
        }

        // Save the new setting as a PlayerPref
        PlayerPrefs.SetInt("fpsIndex", (int)dropdownIndex);
        PlayerPrefs.Save();
    }
}
