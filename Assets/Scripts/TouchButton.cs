using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TouchButton : XRBaseInteractable
{
    private string buttonNumber;
    private Color originalColor;

    private static int _numOfBtnPressed;

    void Start()
    {
        buttonNumber = gameObject.name.Last().ToString();
        originalColor = GetComponent<MeshRenderer>().material.color;
        _numOfBtnPressed = 0;
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (_numOfBtnPressed++ != 0) return;
        base.OnHoverEntered(args);

        Debug.Log("Hover Entered");
        Debug.Log("Button #: " + buttonNumber);
        
        GetComponent<MeshRenderer>().material.color = Color.green;
        NumberPad.KeyPressed(buttonNumber);
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        _numOfBtnPressed--;
        base.OnHoverExited(args);
        
        Debug.Log("Hover Exited");
        GetComponent<MeshRenderer>().material.color = originalColor;
    }
}
