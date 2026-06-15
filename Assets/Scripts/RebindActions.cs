using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class RebindActions : MonoBehaviour
{
    [SerializeField] KeyBindActions keyActionsList;
    [SerializeField] Button buttonUp;
    [SerializeField] Button buttonDown;
    [SerializeField] Button buttonLeft;
    [SerializeField] Button buttonRight;
    [SerializeField] Button buttonFire;
    [SerializeField] Button buttonAltFire;
    [SerializeField] Button buttonJump;

    private bool waitingForKey = false;
    private string keyAction;
    private TMP_Text textChange;

    void Start() {
        keyActionsList.LoadKeys();

        TMP_Text textUp = buttonUp.GetComponentInChildren<TMP_Text>();
        TMP_Text textDown = buttonDown.GetComponentInChildren<TMP_Text>();
        TMP_Text textLeft = buttonLeft.GetComponentInChildren<TMP_Text>();
        TMP_Text textRight = buttonRight.GetComponentInChildren<TMP_Text>();
        TMP_Text textFire = buttonFire.GetComponentInChildren<TMP_Text>();
        TMP_Text textAltFire = buttonAltFire.GetComponentInChildren<TMP_Text>();
        TMP_Text textJump = buttonJump.GetComponentInChildren<TMP_Text>();

        textUp.text = (keyActionsList.moveUp).ToString();
        textDown.text = (keyActionsList.moveDown).ToString();
        textLeft.text = (keyActionsList.moveLeft).ToString();
        textRight.text = (keyActionsList.moveRight).ToString();
        textFire.text = (keyActionsList.actFire).ToString();
        textAltFire.text = (keyActionsList.actAltFire).ToString();
        textJump.text = (keyActionsList.actJump).ToString();

        buttonUp.onClick.AddListener(() => RebindKey("moveUp", textUp));
        buttonDown.onClick.AddListener(() => RebindKey("moveDown", textDown));
        buttonLeft.onClick.AddListener(() => RebindKey("moveLeft", textLeft));
        buttonRight.onClick.AddListener(() => RebindKey("moveRight", textRight));
        buttonFire.onClick.AddListener(() => RebindKey("actFire", textFire));
        buttonAltFire.onClick.AddListener(() => RebindKey("actAltFire", textAltFire));
        buttonJump.onClick.AddListener(() => RebindKey("actJump", textJump));
    }

    public void RebindKey(string actionName, TMP_Text textKey) {
        if (textKey == null) { Debug.LogError("textKey is not assigned in the Unity Inspector!"); return; }
        if (waitingForKey) return;

        waitingForKey = true;
        keyAction = actionName;
        textChange = textKey;

        textChange.text = "Press any key...";
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitingForKey) return;

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(kcode)) {
                SaveNewKey(kcode);
                break;
            }
        }
    }

    void SaveNewKey(KeyCode newKey) {
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
            default:
                Debug.LogWarning($"Action Key, {keyAction}, not found");
                break;
        }

        keyActionsList.SaveKeys();
        textChange.text = newKey.ToString();
        waitingForKey = false;
    }
}
