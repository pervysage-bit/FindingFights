using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyCombatAnimation ECA;
    Rigidbody enemyRb;

    public float speed = 5f;

    Transform playerTarget;

    public float attackDistance = 1f;
    float chasePlayerAfterAttack = 1f;
    float currentAttackTime;
    float deflautAttackTime = 2f;

    bool followPlayer, attackPlayer;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        ECA = GetComponentInChildren<EnemyCombatAnimation>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        currentAttackTime = deflautAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        AttackPlayer();
    }
    void FollowTarget()
    {
        if (!followPlayer)
        {
            return;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            enemyRb.velocity = transform.forward * speed;

            if(enemyRb.velocity.sqrMagnitude != 0)
            {
                Debug.Log("walking");
                ECA.Walk(true);
            }
        }
        else if(Vector3.Distance(transform.position , playerTarget.position) <= attackDistance)
        {
            enemyRb.velocity = Vector3.zero;
            ECA.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }
    void AttackPlayer()
    {
        if (!attackPlayer)
        {
            return;
        }

        currentAttackTime += Time.deltaTime;

        if(currentAttackTime > deflautAttackTime)
        {
            ECA.Attack(Random.Range(0, 2));

            currentAttackTime = 0f;
        }

        if(Vector3.Distance(transform.position , playerTarget.position) >
            attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
