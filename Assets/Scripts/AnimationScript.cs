using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimationScript : XRSimpleInteractable {

    public string openAnimation;
    public string closeAnimation;
    private Animator animator;
    private bool enabled;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
