using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLookedAtEvidence : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    private const string evidenceTag = "Evidence";
    private int lookedAtEvidenceAnimTrigger, hideAnimTrigger;
    private GameObject currentLookedAtEvidence;
    private Animator currentEvidenceAnimator;

    private void Awake()
    {
        lookedAtEvidenceAnimTrigger = Animator.StringToHash(nameof(lookedAtEvidenceAnimTrigger));
        hideAnimTrigger = Animator.StringToHash(nameof(hideAnimTrigger));
    }

    private void FixedUpdate()
    {
        GameObject lookedAtEvidence = GetLookedAtEvidence();

        if (lookedAtEvidence != null && lookedAtEvidence != currentLookedAtEvidence)
        {
            if (currentLookedAtEvidence != null)
                currentEvidenceAnimator.SetTrigger(hideAnimTrigger);

            currentLookedAtEvidence = lookedAtEvidence;
            currentEvidenceAnimator = currentLookedAtEvidence.GetComponent<Animator>();
            currentEvidenceAnimator.SetTrigger(lookedAtEvidenceAnimTrigger);
        }
    }

    private GameObject GetLookedAtEvidence()
    {
        GameObject evidenceLookedAt = null;

        RaycastHit raycastHit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out raycastHit, float.PositiveInfinity))
        {
            if (raycastHit.transform.parent.CompareTag(evidenceTag))
                evidenceLookedAt = raycastHit.transform.parent.gameObject;
        }
        return evidenceLookedAt;
    }
}
