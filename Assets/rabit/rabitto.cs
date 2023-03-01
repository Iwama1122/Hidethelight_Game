using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;//spine‚Æ‚¢‚¤ƒ\ƒtƒg‚É‘Î‰ž‚³‚¹‚é‚½‚ß


public class rabitto : MonoBehaviour
{
    bool tea = false;
    SkeletonAnimation skeletonAnimation;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationName  = "animation";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
           //skeletonAnimation.AnimationState.SetAnimation(3, "animation", true);
            skeletonAnimation.AnimationName = "tea";
            tea = true;
        }
        /*
        if(tea == true) {
            time += Time.deltaTime;
            if(time >= 1.0f) {
                skeletonAnimation.startingAnimation = "animation";
            tea = false;
                time = 0;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            skeletonAnimation.startingAnimation = "animation";
        }
        */
    }
}
