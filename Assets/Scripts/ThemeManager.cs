using UnityEngine;

[CreateAssetMenu(fileName = "ThemeManager", menuName = "Scriptable Objects/ThemeManager")]
public class ThemeManager : ScriptableObject
{
    // Punch Red
    public Color32 primaryColor = new Color32(255, 0, 58, 255);
    // Carmine
    public Color32 primaryShade = new Color32(204, 0, 48, 219);
    // a
    public Color32 secondaryLight = new Color32(255, 0, 187, 219);
    public Color32 secondaryShade = new Color32(255, 68, 0, 219);
    // Tropical Mint
    public Color32 accentColor = new Color32(0, 255, 195, 255);
    // Mint Leaf
    public Color32 accentShade = new Color32(0, 204, 156, 219);
}
