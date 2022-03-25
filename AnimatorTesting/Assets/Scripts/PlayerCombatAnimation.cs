using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombatAnimation : MonoBehaviour
{
    Animator anim;
  
    void Awake()
    {
        anim = GetComponent<Animator>();      
    }

    public void Punch_1()
    {
        anim.SetTrigger(AnimationTag.PUNCH_1_TRIGGER);
    }
    public void Punch_2()
    {
        anim.SetTrigger(AnimationTag.PUNCH_2_TRIGGER);
    }
    public void Punch_3()
    {
        anim.SetTrigger(AnimationTag.PUNCH_3_TRIGGER);
    }
    public void Kick_1()
    {
        anim.SetTrigger(AnimationTag.KICK_1_TRIGGER);
    }
    public void Kick_2()
    {
        anim.SetTrigger(AnimationTag.KICK_2_TRIGGER);
    }
}