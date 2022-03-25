using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum ComboState
{
    NONE, PUNCH_1,PUNCH_2, PUNCH_3, KICK_1, KICK_2
}
public class PlayerCombatAttack : MonoBehaviour
{
    PlayerCombatAnimation PCA;
    float deflautComboTimer = 0.7f;
    float currentComboTimer;
    bool activateTimerToReset;
    ComboState currentComboState;

    private void Awake()
    {
        PCA = GetComponent<PlayerCombatAnimation>();
    }

    void Update()
    {
        ComboAttack();
        ResetComboState();
    }

    public void ComboAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_1 || currentComboState == ComboState.KICK_2)
            {
                return;
            }
                          
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = deflautComboTimer;

            if (currentComboState == ComboState.PUNCH_1)
            {
                PCA.Punch_1();
            }
            if (currentComboState == ComboState.PUNCH_2)
            {
                PCA.Punch_2();
            }
            if (currentComboState == ComboState.PUNCH_3)
            {
                PCA.Punch_3();
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
           if(currentComboState == ComboState.KICK_2 || currentComboState == ComboState.PUNCH_3)
           {
                return;
           }

           if(currentComboState == ComboState.NONE || currentComboState== ComboState.PUNCH_1|| currentComboState == ComboState.PUNCH_2)
           {
                currentComboState = ComboState.KICK_1;
           }
           else if(currentComboState == ComboState.KICK_1)
           {
                currentComboState++;
           }

            currentComboTimer = deflautComboTimer;
            activateTimerToReset = true;

            if(currentComboState == ComboState.KICK_1)
            {
                PCA.Kick_1();
            }
            if (currentComboState == ComboState.KICK_2)
            {
                PCA.Kick_2();
            }
        }
    }

    void ResetComboState()
    {
        currentComboTimer -= Time.deltaTime;

        if (currentComboTimer <= 0)
        {
            activateTimerToReset = false;
            currentComboState = ComboState.NONE;
            currentComboTimer = deflautComboTimer;
        }
    }
}
