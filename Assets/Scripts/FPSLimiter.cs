using TMPro;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdownFPS;
    private int targetFPS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        // Default is case 4
        targetFPS = PlayerPrefs.GetInt("fpsIndex", (int)4);

        FpsChanger(targetFPS);
        dropdownFPS.SetValueWithoutNotify(targetFPS);
    }

    public void FpsChanger(int dropdownIndex)
    {
        switch (dropdownIndex)
        {
            case 0:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 30;
                break;
            case 1:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 60;
                break;
            case 2:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 120;
                break;
            case 3:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = -1;
                break;
            case 4:
                QualitySettings.vSyncCount = 1;
                Application.targetFrameRate = -1;
                break;
        }

        PlayerPrefs.SetInt("fpsIndex", (int)dropdownIndex);
        PlayerPrefs.Save();
    }
}
