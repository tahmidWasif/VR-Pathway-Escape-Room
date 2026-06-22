using System.Numerics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using Vector3 = UnityEngine.Vector3;

public class CardReader : XRSocketInteractor
{
    [Header("Card Reader")] 
    [SerializeField] private GameObject lockingBar;
    [SerializeField] private DoorHandle doorHandle;

    private Transform keyCardTransform;
    private Vector3 hoverEntry, displacement;
    private bool isValid;

    void Start()
    {
        doorHandle.enabled = false;
    }
    void Update()
    {
        if (keyCardTransform != null)
        {
            Vector3 keycardUp = keyCardTransform.forward;
            float dot = Vector3.Dot(keycardUp, Vector3.up);

            if (dot < 0.8)
            {
                isValid = false;
            }
        }
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return false;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        
        keyCardTransform = args.interactableObject.transform;
        hoverEntry = keyCardTransform.position;
        isValid = true;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        displacement = keyCardTransform.position - hoverEntry;
        Debug.Log(displacement);

        if (isValid && displacement.y < -0.3f)
        {
            Debug.Log("Displacement success");
            lockingBar.SetActive(false);
            doorHandle.enabled = true;
        }

        keyCardTransform = null;
    }
}
