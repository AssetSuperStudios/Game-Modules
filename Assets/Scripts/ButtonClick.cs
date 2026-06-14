using UnityEngine;
using UnityEngine.UI;

// Make sure this script is always loaded

public class ButtonClick : MonoBehaviour
{
    public Button buttonGraphics;
    public Canvas canvasGraphics;
    public Button buttonAudio;
    public Canvas canvasAudio;
    public Button buttonControls;
    public Canvas canvasControls;
    public Button buttonCredits;
    public Canvas canvasCredits;
    public Button buttonExit;
    public Canvas canvasExit;
    public Button buttonEnter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonGraphics.onClick.AddListener(OnClickGraphics);
        buttonAudio.onClick.AddListener(OnClickAudio);
        buttonControls.onClick.AddListener(OnClickControls);
        buttonCredits.onClick.AddListener(OnClickCredits);
        buttonExit.onClick.AddListener(OnClickExit);
        buttonEnter.onClick.AddListener(OnClickEnter);
    }

    void OnClickGraphics()
    {
        // Debug.Log("You have changed the Canvas to Graphics");
        canvasGraphics.sortingOrder = 5;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;

        buttonGraphics.interactable = false;
        buttonAudio.interactable = true;
        buttonControls.interactable = true;
        buttonCredits.interactable = true;
        buttonExit.interactable = true;
    }

    void OnClickAudio()
    {
        // Debug.Log("You have changed the Canvas to Audio");
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 5;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;

        buttonGraphics.interactable = true;
        buttonAudio.interactable = false;
        buttonControls.interactable = true;
        buttonCredits.interactable = true;
        buttonExit.interactable = true;
    }

        void OnClickControls()
    {
        // Debug.Log("You have changed the Canvas to Controls");
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 5;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;

        buttonGraphics.interactable = true;
        buttonAudio.interactable = true;
        buttonControls.interactable = false;
        buttonCredits.interactable = true;
        buttonExit.interactable = true;
    }

    void OnClickCredits()
    {
        // Debug.Log("You have changed the Canvas to Credits");
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 5;
        canvasExit.sortingOrder = 0;

        buttonGraphics.interactable = true;
        buttonAudio.interactable = true;
        buttonControls.interactable = true;
        buttonCredits.interactable = false;
        buttonExit.interactable = true;
    }

    void OnClickExit()
    {
        // Debug.Log("You have changed the Canvas to Exit");
        canvasExit.gameObject.SetActive(false);
    }

    void OnClickEnter()
    {
        // Debug.Log("You have opened the settings menu");
        canvasExit.gameObject.SetActive(true);

        AudioSource buttonClickSound = buttonEnter.GetComponent<AudioSource>();

        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }

}
