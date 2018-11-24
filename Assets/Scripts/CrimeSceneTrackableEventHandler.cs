using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimeSceneTrackableEventHandler : DefaultTrackableEventHandler
{
    [SerializeField]
    private GameObject trackingIndicator;

    protected override void OnTrackingFound()
    {
        trackingIndicator.SetActive(true);
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
        {
            if (!component.gameObject.name.Contains("Hitbox"))
                component.enabled = true;
        }

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        trackingIndicator.SetActive(false);
    }

}
