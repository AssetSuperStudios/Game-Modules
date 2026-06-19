using UnityEngine;

[CreateAssetMenu(fileName = "KeyBindActions", menuName = "Scriptable Objects/KeyBindActions")]
public class KeyBindActions : ScriptableObject
{
    // List of KeyCode actions
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode actFire = KeyCode.LeftControl;
    public KeyCode actAltFire = KeyCode.LeftShift;
    public KeyCode actJump = KeyCode.Space;

    // The following are the names of the PlayerPrefs used in this script
    // "keyMoveUp", "keyMoveDown", "keyMoveLeft", "keyMoveRight", "keyActFire", "keyActAltFire", "keyActJump"

    // Sets the current keys to the saved PlayerPrefs, if it does not have any stored, it uses the default (int)KeyCode
    public void LoadKeys() {
        moveUp = (KeyCode)PlayerPrefs.GetInt("keyMoveUp", (int)KeyCode.W);
        moveDown = (KeyCode)PlayerPrefs.GetInt("keyMoveDown", (int)KeyCode.S);
        moveLeft = (KeyCode)PlayerPrefs.GetInt("keyMoveLeft", (int)KeyCode.A);
        moveRight = (KeyCode)PlayerPrefs.GetInt("keyMoveRight", (int)KeyCode.D);
        actFire = (KeyCode)PlayerPrefs.GetInt("keyActFire", (int)KeyCode.LeftControl);
        actAltFire = (KeyCode)PlayerPrefs.GetInt("keyActAltFire", (int)KeyCode.LeftShift);
        actJump = (KeyCode)PlayerPrefs.GetInt("keyActJump", (int)KeyCode.Space);
    }

    // Saves the current keys as PlayerPrefs
    // Call this when rebinding
    public void SaveKeys() {
        PlayerPrefs.SetInt("keyMoveUp", (int)moveUp);
        PlayerPrefs.SetInt("keyMoveDown", (int)moveDown);
        PlayerPrefs.SetInt("keyMoveLeft", (int)moveLeft);
        PlayerPrefs.SetInt("keyMoveRight", (int)moveRight);
        PlayerPrefs.SetInt("keyActFire", (int)actFire);
        PlayerPrefs.SetInt("keyActAltFire", (int)actAltFire);
        PlayerPrefs.SetInt("keyActJump", (int)actJump);
        PlayerPrefs.Save();
    }

    // INSTRUCTIONS ON HOW TO USE THE NEW KEYCODE ACTIONS IN THE GAME //
    // Add this "[SerializeField] KeyBindActions keyActionsList;" and drag the keyActionsList to your script
    // Use "Input.GetKey(<name>.<keycode>)" to check for the button press
    // KeyBindActions <name> => this script
    // KeyCode <keycode> = KeyCode.<keyname>;
}
