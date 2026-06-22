using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DoorHandle : XRBaseInteractable
{
    public Transform door;
    public Vector3 localDragDirection;
    public float dragDistance;
    public int DoorWeight = 20;

    private Vector3 startPosition, endPosition, worldDragDirection;

    private void Start()
    {
        worldDragDirection = transform.TransformDirection(localDragDirection).normalized;
        
        startPosition = door.position;
        endPosition = startPosition + worldDragDirection * dragDistance;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (isSelected)
        {
            var interactorTransform = firstInteractorSelecting.GetAttachTransform(this);
            Vector3 selfToInteractor = interactorTransform.position - transform.position;
            
            float dot = Vector3.Dot(selfToInteractor.normalized, worldDragDirection);
            float speed = Mathf.Abs(dot) / DoorWeight;

            if (dot > 0)
            {
                door.position = Vector3.MoveTowards(door.position, endPosition, Time.deltaTime * speed);
            }
            else if (dot < 0)
            {
                door.position = Vector3.MoveTowards(door.position, startPosition, speed * Time.deltaTime);
            }
        }
    }
}
