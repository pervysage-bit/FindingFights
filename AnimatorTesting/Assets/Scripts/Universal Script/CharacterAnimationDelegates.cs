using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegates : MonoBehaviour
{
    public GameObject leftArmPoint, rightArmPoint, leftLegPoint, rightLegPoint;

    void LeftArmAttackOn()
    {
        leftArmPoint.SetActive(true);
    }
    void Left_ArmAttackOff()
    {
        if (leftArmPoint.activeInHierarchy)
        {
            leftArmPoint.SetActive(false);
        }
    }
    void Right_ArmAttackOn()
    {
        leftArmPoint.SetActive(true);
    }
    void Right_ArmAttackOff()
    {
        if (leftArmPoint.activeInHierarchy)
        {
            leftArmPoint.SetActive(false);
        }
    }
    void Left_LegAttackOn()
    {
        leftArmPoint.SetActive(true);
    }
    void Left_LegAttackOff()
    {
        if (leftArmPoint.activeInHierarchy)
        {
            leftArmPoint.SetActive(false);
        }
    }
    void Right_LegAttackOn()
    {
        leftArmPoint.SetActive(true);
    }
    void Right_LegAttackOff()
    {
        if (leftArmPoint.activeInHierarchy)
        {
            leftArmPoint.SetActive(false);
        }
    }

    void TagLeftArm()
    {
        leftArmPoint.tag = Tags.LEFT_ARM_TAG;
    }
    void UntagLeftArm()
    {
        leftArmPoint.tag = Tags.UNTAGGED_TAG;
    }
    void TagLeftLeg()
    {
        leftLegPoint.tag = Tags.LEFT_LEG_TAG;
    }
    void UntagLeftLeg()
    {
        leftLegPoint.tag = Tags.UNTAGGED_TAG;
    }
}
