using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectInterface : MonoBehaviour
{
    private static SuspectInterface instance;
    private int goToSuspectSelectedAnimTrigger = Animator.StringToHash(nameof(goToSuspectSelectedAnimTrigger));
    private int backAnimTrigger = Animator.StringToHash(nameof(backAnimTrigger));
    private Animator animator;

    public static SuspectInterface Instance
    {
        get
        {
            if (instance == null)
            {
                var gameObject = GameObject.Find(nameof(SuspectInterface));
                instance = gameObject.AddComponent<SuspectInterface>();
                instance.Initialize();
            }
            return instance;
        }
    }

    public void GoToSuspectSelectedState()
    {
        animator.SetTrigger(goToSuspectSelectedAnimTrigger);
    }

    public void GoBack()
    {
        animator.SetTrigger(backAnimTrigger);
    }

    private void Initialize()
    {
        animator = GetComponent<Animator>();
    }
}
