using UnityEngine;
using TMPro;
using System;

public class QualityChanger : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown dropdownQuality;
    private int currentQuality;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentQuality = QualitySettings.GetQualityLevel() - 2;
        currentQuality = PlayerPrefs.GetInt("qualityIndex", (int)currentQuality);

        dropdownQuality.SetValueWithoutNotify(currentQuality);
        QualitySettings.SetQualityLevel(currentQuality + 2);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex + 2);

        PlayerPrefs.SetInt("qualityIndex", (int)qualityIndex);
        PlayerPrefs.Save();
    }
}
