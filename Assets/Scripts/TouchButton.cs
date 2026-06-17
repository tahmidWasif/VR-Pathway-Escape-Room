using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TouchButton : XRBaseInteractable
{
    [Header("TouchPad")]
    [SerializeField] private GameObject[] buttons;

    private void OnEnable()
    {
        foreach (var button in buttons)
        {
            
        }
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        Debug.Log("Hover Entered");
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
