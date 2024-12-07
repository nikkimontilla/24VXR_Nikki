using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;

public class objectInteractableRotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Rotation sensitivity - lower values mean slower rotation")]
    public float rotationSpeed = 2f;

    [Tooltip("Rotation axis")]
    public RotationAxis rotationAxis = RotationAxis.Free;

    [Tooltip("Limit rotation on X axis")]
    public bool limitXRotation = false;

    [Tooltip("Minimum X rotation angle")]
    public float minXAngle = -90f;

    [Tooltip("Maximum X rotation angle")]
    public float maxXAngle = 90f;

    public enum RotationAxis
    {
        Free,
        XAxis,
        YAxis,
        ZAxis
    }

    private XRRayInteractor rayInteractor;
    private Vector3 previousControllerPosition;
    private bool isRotating = false;

    void Start()
    {
        // Find the XR Ray Interactor on the right controller
        rayInteractor = GetComponentInParent<XRRayInteractor>();
    }

    void Update()
    {
        // Check if ray interactor is valid
        if (rayInteractor == null) return;

        // Check if the object is currently selected
        if (rayInteractor.selectTarget != null)
        {
            // Get the controller's position
            Vector3 controllerPosition = rayInteractor.transform.position;

            // First frame of rotation
            if (!isRotating)
            {
                previousControllerPosition = controllerPosition;
                isRotating = true;
            }

            // Calculate rotation delta
            Vector3 deltaPosition = controllerPosition - previousControllerPosition;

            // Rotate based on selected axis
            switch (rotationAxis)
            {
                case RotationAxis.Free:
                    // Free rotation following controller movement
                    transform.Rotate(
                        deltaPosition.y * rotationSpeed,
                        -deltaPosition.x * rotationSpeed,
                        deltaPosition.z * rotationSpeed,
                        Space.World
                    );
                    break;

                case RotationAxis.XAxis:
                    float xRotation = -deltaPosition.y * rotationSpeed;

                    if (limitXRotation)
                    {
                        // Calculate current X rotation and check limits
                        float currentXRotation = transform.localEulerAngles.x;
                        float potentialRotation = Mathf.Clamp(
                            currentXRotation + xRotation,
                            minXAngle,
                            maxXAngle
                        );

                        transform.localEulerAngles = new Vector3(
                            potentialRotation,
                            transform.localEulerAngles.y,
                            transform.localEulerAngles.z
                        );
                    }
                    else
                    {
                        transform.Rotate(xRotation, 0, 0, Space.World);
                    }
                    break;

                case RotationAxis.YAxis:
                    transform.Rotate(0, -deltaPosition.x * rotationSpeed, 0, Space.World);
                    break;

                case RotationAxis.ZAxis:
                    transform.Rotate(0, 0, deltaPosition.x * rotationSpeed, Space.World);
                    break;
            }

            // Update previous position
            previousControllerPosition = controllerPosition;
        }
        else
        {
            // Reset rotation tracking when not rotating
            isRotating = false;
        }
    }
}
