using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    // Serialized objects for the color list and objects to apply the color list with
    [SerializeField] private ThemeManager colorList;
    [SerializeField] private GameObject[] primaryGameObjects;
    [SerializeField] private GameObject[] accentGameObjects;

    // Applies a color theme to a list of GameObjects
    // Accepts the list of Game Objects alongside 4 color parameters
    void ApplyColorToGroup(GameObject[] targetGroup, Color32 targetColor, Color32 accentColor, Color32 secondaryLight, Color32 secondaryShade)
    {
        // Loop through each GameObject
        foreach (GameObject targetObject in targetGroup)
        {
            // Get its Image, Text and Button child components
            Image img = targetObject.GetComponent<Image>();
            TextMeshProUGUI[] txts = targetObject.GetComponentsInChildren<TextMeshProUGUI>();
            Button[] btns = targetObject.GetComponentsInChildren<Button>();

            // Changes the Image's color if it exists
            // Log a warning if it does not
            // Uses the Primary for Images
            if (img != null)
            {
                img.color = targetColor;
            }
            else
            {
                Debug.LogWarning($"Missing image component for '{targetObject.name}'", targetObject);
            }

            // Changes the color of all the Texts if they exist
            // Log a warning if they do not
            // Uses an Accent for Texts
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

            // Changes the color of all the Buttons if they exist
            // Log a warning if they do not
            // Uses the Secondary for Buttons and its shade version for its interactions
            if (btns != null && btns.Count() != 0)
            {
                foreach (Button btn in btns)
                {
                    ColorBlock cb = btn.colors;
                    cb.normalColor = cb.selectedColor = secondaryLight;
                    cb.highlightedColor = cb.pressedColor = cb.disabledColor = secondaryShade;

                    // Need to reassign the color block back to the button again
                    btn.colors = cb;
                }
            }
            else
            {
                Debug.LogWarning($"Missing button component for '{targetObject.name}'", targetObject);
            }
        }
    }

    // Change the color during game start
    void Start()
    {
        // Original Theme
        ApplyColorToGroup(primaryGameObjects, colorList.primaryColor, colorList.accentColor, colorList.secondaryLight, colorList.secondaryShade);
        // Inverse Theme
        ApplyColorToGroup(accentGameObjects, colorList.accentColor, colorList.primaryColor, colorList.secondaryShade, colorList.secondaryLight);
    }
}
