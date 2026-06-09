using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private ThemeManager colorList;
    [SerializeField] private GameObject[] primaryGameObjects;
    [SerializeField] private GameObject[] accentGameObjects;

    void ApplyColorToGroup(GameObject[] targetGroup, Color32 targetColor, Color32 accentColor, Color32 secondaryLight, Color32 secondaryShade)
    {
        foreach (GameObject targetObject in targetGroup)
        {
            Image img = targetObject.GetComponent<Image>();
            TextMeshProUGUI[] txts = targetObject.GetComponentsInChildren<TextMeshProUGUI>();
            Button[] btns = targetObject.GetComponentsInChildren<Button>();

            if (img != null)
            {
                img.color = targetColor;
            }
            else
            {
                Debug.LogWarning($"Missing image component for '{targetObject.name}'", targetObject);
            }

            if (txts != null && txts.Count() != 0)
            {
                foreach (TextMeshProUGUI txt in txts)
                {
                    txt.color = accentColor;
                }
            }
            else
            {
                Debug.LogWarning($"Missing text component for '{targetObject.name}'", targetObject);
            }

            if (btns != null && btns.Count() != 0)
            {
                foreach (Button btn in btns)
                {
                    ColorBlock cb = btn.colors;
                    cb.normalColor = cb.selectedColor = secondaryLight;
                    cb.highlightedColor = cb.pressedColor = cb.disabledColor = secondaryShade;

                    btn.colors = cb;
                }
            }
            else
            {
                Debug.LogWarning($"Missing button component for '{targetObject.name}'", targetObject);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Original Theme
        ApplyColorToGroup(primaryGameObjects, colorList.primaryColor, colorList.accentColor, colorList.secondaryLight, colorList.secondaryShade);
        // Inverse Theme
        ApplyColorToGroup(accentGameObjects, colorList.accentColor, colorList.primaryColor, colorList.secondaryShade, colorList.secondaryLight);
    }
}
