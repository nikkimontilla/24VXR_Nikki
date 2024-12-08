using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class userBoundaries : MonoBehaviour
{
    [Header("Boundary Settings")]
    public Transform platformCenter;
    public float maxAllowedDistance = 5f;

    [Header("XR References")]
    public ActionBasedContinuousMoveProvider continuousMoveProvider;
    public Transform xrOrigin;

    private Vector3 lastValidPosition;

    private void Start()
    {
        // Validate references
        if (platformCenter == null)
        {
            Debug.LogError("Platform Center is not assigned!");
            enabled = false;
            return;
        }

        if (xrOrigin == null)
        {
            Debug.LogError("XR Origin is not assigned!");
            enabled = false;
            return;
        }

        // Initial valid position
        lastValidPosition = xrOrigin.position;
    }

    private void Update()
    {
        // Calculate distance from platform center (ignoring Y-axis)
        Vector3 platformOffset = xrOrigin.position - platformCenter.position;
        platformOffset.y = 0;

        // Check if outside boundary
        if (platformOffset.magnitude > maxAllowedDistance)
        {
            // Revert to last valid position
            xrOrigin.position = lastValidPosition;

            // Optional: Stop movement
            if (continuousMoveProvider != null)
            {
                continuousMoveProvider.moveSpeed = 0;
            }

            Debug.Log("Boundary exceeded. Movement restricted.");
        }
        else
        {
            // Update last valid position
            lastValidPosition = xrOrigin.position;

            // Restore movement speed if it was stopped
            if (continuousMoveProvider != null)
            {
                continuousMoveProvider.moveSpeed = 3f; // Default or your preferred speed
            }
        }
    }

    // Visualize boundary in Scene view
    private void OnDrawGizmosSelected()
    {
        if (platformCenter != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(platformCenter.position, maxAllowedDistance);
        }
    }
}
