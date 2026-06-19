using UnityEngine;
using TMPro;
using System;

public class QualityChanger : MonoBehaviour
{
    // Serialized dropdown object
    [SerializeField] public TMP_Dropdown dropdownQuality;
    // Integer variable declaration
    private int currentQuality;

    // The following are the names of the PlayerPrefs used in this script
    // "qualityIndex"

    void Awake()
    {
        // Get the default quality settings as default value
        // Get the actual quality settings in the PlayerPrefs
        // With the default value as fallback
        // Currently the Quality Levels list are as follows:
        // [0] Mobile, [1] PC, [2] Low, [3] Medium, [4] High
        // With Medium as the default for web apps and High for PCs
        // The dropdown only has 3 values, hence the additional +- 2 for the index
        currentQuality = QualitySettings.GetQualityLevel() - 2;
        currentQuality = PlayerPrefs.GetInt("qualityIndex", (int)currentQuality);

        // Set the quality for the dropdown and the actual settings
        dropdownQuality.SetValueWithoutNotify(currentQuality);
        QualitySettings.SetQualityLevel(currentQuality + 2);
    }

    public void SetQuality(int qualityIndex)
    {
        // Set Quality level based on the dropdown's index
        QualitySettings.SetQualityLevel(qualityIndex + 2);

        // Save the new value as PlayerPrefs
        PlayerPrefs.SetInt("qualityIndex", (int)qualityIndex);
        PlayerPrefs.Save();
    }
}
