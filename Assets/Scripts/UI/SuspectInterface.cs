using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectInterface : MonoBehaviour
{
    [SerializeField]
    private Image selectedSuspectPortraitImage, selectedSuspectPortraitHighlightImage;

    private static SuspectInterface instance;
    private int goToSuspectSelectedAnimTrigger = Animator.StringToHash(nameof(goToSuspectSelectedAnimTrigger));
    private int goToCaseFileSelectedAnimTrigger = Animator.StringToHash(nameof(goToCaseFileSelectedAnimTrigger));
    private int backAnimTrigger = Animator.StringToHash(nameof(backAnimTrigger));
    private Animator animator;

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public static SuspectInterface Instance
    {
        get
        {
            //if (instance == null)
            //{
            //    var gameObject = GameObject.Find(nameof(SuspectInterface));
            //    instance = gameObject.AddComponent<SuspectInterface>();
            //    instance.Initialize();
            //}
            return instance;
        }
    }

    public void GoToSuspectSelectedState(Character selectedCharacter)
    {
        selectedSuspectPortraitImage.sprite = selectedCharacter.PortraitSprite;
        selectedSuspectPortraitHighlightImage.sprite = selectedCharacter.PortraitHighlightSprite;
        animator.SetTrigger(goToSuspectSelectedAnimTrigger);
    }

    public void GoToCaseFileSelectedState()
    {
        animator.SetTrigger(goToCaseFileSelectedAnimTrigger);
    }

    public void GoBack()
    {
        animator.SetTrigger(backAnimTrigger);
    }
}
