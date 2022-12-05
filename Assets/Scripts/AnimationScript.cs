using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimationScript : XRSimpleInteractable {

    public string openAnimation;
    public string openAnimation2;
    public string closeAnimation;
    private Animator animator;
    private bool enable = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            enable = true;
            animator.Play(openAnimation);
        }

        if (Input.GetKey(KeyCode.K))
        {
            enable = true;
            animator.Play(openAnimation2);
        }
    }

    //pointing at controller and hitting select button
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        enable = !enable;
        if (enable == true)
        {
            animator.Play(openAnimation);
        }
        else
        {
            animator.Play(closeAnimation);
        }
    }

}
