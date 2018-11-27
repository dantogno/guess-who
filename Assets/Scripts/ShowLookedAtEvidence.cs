using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLookedAtEvidence : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    private const string evidenceTag = "Evidence";
    private Evidence lastLookedAtEvidence; 

    private void FixedUpdate()
    {
        Evidence lookedAtEvidence = GetLookedAtEvidence();

        if (lookedAtEvidence != null)
        {
            if (lastLookedAtEvidence != null)
                lastLookedAtEvidence.IsBeingLookedAt = false;

            lookedAtEvidence.IsBeingLookedAt = true;
            lastLookedAtEvidence = lookedAtEvidence;
        }
        else if (lastLookedAtEvidence != null)
        {
            lastLookedAtEvidence.IsBeingLookedAt = false;
            lastLookedAtEvidence = null;
        }
    }

    private Evidence GetLookedAtEvidence()
    {
        Evidence lookedAtEvidence = null;

        RaycastHit raycastHit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out raycastHit, float.PositiveInfinity))
        {
            if (raycastHit.transform.parent.CompareTag(evidenceTag))
                lookedAtEvidence = raycastHit.transform.parent.gameObject.GetComponent<Evidence>();
        }
        return lookedAtEvidence;
    }
}
