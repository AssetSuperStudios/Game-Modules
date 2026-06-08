using UnityEngine;
using UnityEngine.UI;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonGraphics.onClick.AddListener(OnClickGraphics);
        buttonAudio.onClick.AddListener(OnClickAudio);
        buttonControls.onClick.AddListener(OnClickControls);
        buttonCredits.onClick.AddListener(OnClickCredits);
        buttonExit.onClick.AddListener(OnClickExit);
    }

    void OnClickGraphics()
    {
        // Debug.Log("You have changed the Canvas to Graphics");
        canvasGraphics.sortingOrder = 5;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;
    }

    void OnClickAudio()
    {
        // Debug.Log("You have changed the Canvas to Audio");
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 5;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;
    }

        void OnClickControls()
    {
        // Debug.Log("You have changed the Canvas to Controls");
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 5;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 0;
    }

    void OnClickCredits()
    {
        // Debug.Log("You have changed the Canvas to Credits");
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 5;
        canvasExit.sortingOrder = 0;
    }

    void OnClickExit()
    {
        // Debug.Log("You have changed the Canvas to Exit");
        canvasGraphics.sortingOrder = 0;
        canvasAudio.sortingOrder = 0;
        canvasControls.sortingOrder = 0;
        canvasCredits.sortingOrder = 0;
        canvasExit.sortingOrder = 5;
    }

}
