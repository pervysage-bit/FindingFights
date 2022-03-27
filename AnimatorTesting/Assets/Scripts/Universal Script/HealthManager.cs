using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health = 100f;

    private EnemyCombatAnimation enemy_ca;
    private PlayerCombatAnimation player_ca;

    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;

    private void Awake()
    {
        enemy_ca = GetComponentInChildren<EnemyCombatAnimation>();
        player_ca = GetComponentInChildren<PlayerCombatAnimation>();
    }

    public void ApplyDamage(float damage)
    {
        if (characterDied)
        {
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            enemy_ca.Death();
            //player_ca.Death();
            characterDied = true;

             if (is_Player)
             {

             }
        }

        if (!is_Player)
        {
            //if(Random.Range(0,3) > 1)
            //{
            //    enemy_ca.Hit();
            //    Debug.Log("i hit you,,");
            //}
            enemy_ca.Hit();
            Debug.Log("i hit you,,");
        }

    }
}
