using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Make sure this script is always loaded

public class ButtonClick : MonoBehaviour
{
    public ScrollRect scrollRect;
    // Button objects
    public Button buttonGraphics;
    public Button buttonAudio;
    public Button buttonControls;
    public Button buttonCredits;
    public Button buttonExit;
    public Button buttonEnter;

    // Canvas objects
    public Canvas canvasGraphics;
    public Canvas canvasAudio;
    public Canvas canvasControls;
    public Canvas canvasCredits;
    public Canvas canvasExit;
    
    // Declare coroutine variable
    private Coroutine scrollCoroutine;

    void Start()
    {
        // Adds an on click listener to each button and binds the corresponding function to them
        // You can remove this and instead manually bind the functions to the button's onClick Component
        // The problem is that you still need to change the properties of the other buttons
        // And the only way to do that is to pass each affected button, giving the function 5 parameters
        // However, functions with more than 1 parameters cannot be assigned in the onClick component of an object
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
        // Move up the graphics settings
        canvasGraphics.sortingOrder = 5;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;

        // Disable the button for the graphics settings
        buttonGraphics.interactable = false;
        buttonAudio.interactable = true;
        buttonControls.interactable = true;
        buttonCredits.interactable = true;
        buttonExit.interactable = true;

        // Stop the glide animation
        if (scrollCoroutine != null) {StopCoroutine(scrollCoroutine);}
    }

    void OnClickAudio()
    {
        // Debug.Log("You have changed the Canvas to Audio");
        // Move up the audio settings
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 5;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;

        // Disable the button for the audio settings
        buttonGraphics.interactable = true;
        buttonAudio.interactable = false;
        buttonControls.interactable = true;
        buttonCredits.interactable = true;
        buttonExit.interactable = true;

        // Stop the glide animation
        if (scrollCoroutine != null) {StopCoroutine(scrollCoroutine);}
    }

        void OnClickControls()
    {
        // Debug.Log("You have changed the Canvas to Controls");
        // Move up the controls settings
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 5;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;

        // Disable the button for the controls settings
        buttonGraphics.interactable = true;
        buttonAudio.interactable = true;
        buttonControls.interactable = false;
        buttonCredits.interactable = true;
        buttonExit.interactable = true;

        // Stop the glide animation
        if (scrollCoroutine != null) {StopCoroutine(scrollCoroutine);}
    }

    void OnClickCredits()
    {
        // Debug.Log("You have changed the Canvas to Credits");
        // Move up the credits settings
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 5;
        canvasExit.sortingOrder = 0;

        // Disable the button for the credits settings
        buttonGraphics.interactable = true;
        buttonAudio.interactable = true;
        buttonControls.interactable = true;
        buttonCredits.interactable = false;
        buttonExit.interactable = true;

        // Snap the Scroll View to top
        // Start the glide animation
        scrollRect.verticalNormalizedPosition = 1f;
        scrollCoroutine = StartCoroutine(ScrollDown());
    }

    void OnClickExit()
    {
        // Debug.Log("You have changed the Canvas to Exit");
        // Unpause the game
        Time.timeScale = 1;
        // Close settings menu
        canvasExit.gameObject.SetActive(false);

        // Stop the glide animation
        if (scrollCoroutine != null) {StopCoroutine(scrollCoroutine);}
    }

    void OnClickEnter()
    {
        // Debug.Log("You have opened the settings menu");
        // Pause the game
        Time.timeScale = 0;
        // Open settings menu
        canvasExit.gameObject.SetActive(true);

        // Play button click sound
        AudioSource buttonClickSound = buttonEnter.GetComponent<AudioSource>();
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }

    private IEnumerator ScrollDown()
    {
        // Waits for 3 seconds to finish
        yield return new WaitForSeconds(3f);

        // Loop scrolling to the bottom
        // By subtracting the normalized position with scroll speed based on delta time
        while (scrollRect.verticalNormalizedPosition > 0f)
        {
            scrollRect.verticalNormalizedPosition -= 0.1f * Time.deltaTime;
            // Wait to complete the next frame before looping
            yield return null;
        }

        // Ensure it locks perfectly to the bottom when finished
        scrollRect.verticalNormalizedPosition = 0f;
    }

}
