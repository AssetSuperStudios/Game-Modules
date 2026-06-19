using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class RebindActions : MonoBehaviour
{
    // Serialized game objects for the key actions and buttons
    [SerializeField] KeyBindActions keyActionsList;
    [SerializeField] Button buttonUp;
    [SerializeField] Button buttonDown;
    [SerializeField] Button buttonLeft;
    [SerializeField] Button buttonRight;
    [SerializeField] Button buttonFire;
    [SerializeField] Button buttonAltFire;
    [SerializeField] Button buttonJump;

    // Variable declaration for bool, string and Text - TMP
    private bool waitingForKey = false;
    private string keyAction;
    private TMP_Text textChange;

    void Start() {
        // Call the LoadKeys() 
        // Sets the keys in keyActionsList scriptable according to PlayerPrefs
        keyActionsList.LoadKeys();

        // Get the text label component for each buttons
        TMP_Text textUp = buttonUp.GetComponentInChildren<TMP_Text>();
        TMP_Text textDown = buttonDown.GetComponentInChildren<TMP_Text>();
        TMP_Text textLeft = buttonLeft.GetComponentInChildren<TMP_Text>();
        TMP_Text textRight = buttonRight.GetComponentInChildren<TMP_Text>();
        TMP_Text textFire = buttonFire.GetComponentInChildren<TMP_Text>();
        TMP_Text textAltFire = buttonAltFire.GetComponentInChildren<TMP_Text>();
        TMP_Text textJump = buttonJump.GetComponentInChildren<TMP_Text>();

        // Change the text value to the new keys list
        textUp.text = (keyActionsList.moveUp).ToString();
        textDown.text = (keyActionsList.moveDown).ToString();
        textLeft.text = (keyActionsList.moveLeft).ToString();
        textRight.text = (keyActionsList.moveRight).ToString();
        textFire.text = (keyActionsList.actFire).ToString();
        textAltFire.text = (keyActionsList.actAltFire).ToString();
        textJump.text = (keyActionsList.actJump).ToString();

        // adds an on click listener to each button for key rebinding
        buttonUp.onClick.AddListener(() => RebindKey("moveUp", textUp));
        buttonDown.onClick.AddListener(() => RebindKey("moveDown", textDown));
        buttonLeft.onClick.AddListener(() => RebindKey("moveLeft", textLeft));
        buttonRight.onClick.AddListener(() => RebindKey("moveRight", textRight));
        buttonFire.onClick.AddListener(() => RebindKey("actFire", textFire));
        buttonAltFire.onClick.AddListener(() => RebindKey("actAltFire", textAltFire));
        buttonJump.onClick.AddListener(() => RebindKey("actJump", textJump));
    }

    // Accepts a string keyAction, and a Text - TMP game object as parameters 
    public void RebindKey(string actionName, TMP_Text textKey) {
        // In case the Text game object does not exist
        // If the game is currently rebinding, prevent other keys from being rebound
        if (textKey == null) { Debug.LogError("textKey is not assigned in the Unity Inspector!"); return; }
        if (waitingForKey) return;

        // Change waitingForKey to true, to start the rebind process
        // Sets keyAction to the string parameter
        // Passes the Text parameter to the declared Text variab
        waitingForKey = true;
        keyAction = actionName;
        textChange = textKey;

        // Changes the Text temporarily
        textChange.text = "Press any key...";
    }

    void Update()
    {
        // Waits for the waitingForKey to be true
        if (!waitingForKey) return;

        // Loops through each possible key code to check of it has been pressed
        // Stores the key pressed and passes it to SaveNewKey()
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(kcode)) {
                SaveNewKey(kcode);
                break;
            }
        }
    }

    void SaveNewKey(KeyCode newKey) {
        // Changes the corresponding keyAction with the KeyCode parameter passed
        switch (keyAction)
        {
            case "moveUp":
                keyActionsList.moveUp = newKey;
                break;
            case "moveDown":
                keyActionsList.moveDown = newKey;
                break;
            case "moveLeft":
                keyActionsList.moveLeft = newKey;
                break;
            case "moveRight":
                keyActionsList.moveRight = newKey;
                break;
            case "actFire":
                keyActionsList.actFire = newKey;
                break;
            case "actAltFire":
                keyActionsList.actAltFire = newKey;
                break;
            case "actJump":
                keyActionsList.actJump = newKey;
                break;
            // In case the keyAction does not exist
            default:
                Debug.LogWarning($"Action Key, {keyAction}, not found");
                break;
        }

        // Calls the SaveKeys()
        // Saves the new key to PlayerPrefs
        // Changes the Text - TMP value to the new key
        // Returns waitingForKey to false just before finishing the function call
        keyActionsList.SaveKeys();
        textChange.text = newKey.ToString();
        waitingForKey = false;
    }
}
