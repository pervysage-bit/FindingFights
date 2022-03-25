using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatAnimation : MonoBehaviour
{
    Animator enemyAnim;

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }

 
    public void Walk(bool walk)
    {
        if (walk)
        {
            enemyAnim.SetBool(AnimationTag.IS_WALKING, true);
        }
        else if (!walk)
        {
            enemyAnim.SetBool(AnimationTag.IS_WALKING, false);
        }
        
    }

    public void Attack(int attack)
    {
        if(attack == 0)
        {
            enemyAnim.SetTrigger(AnimationTag.ATTACK_1_TRIGGER);
        }
        if (attack == 1)
        {
            enemyAnim.SetTrigger(AnimationTag.ATTACK_2_TRIGGER);
        }
    }

    public void Hit()
    {
        enemyAnim.SetTrigger(AnimationTag.HIT_TRIGGER);
    }
    public void Death()
    {
        enemyAnim.SetTrigger(AnimationTag.DEATH_TRIGGER);
    }


}
