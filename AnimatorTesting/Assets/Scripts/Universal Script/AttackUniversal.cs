using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer, isEnemy;

    void Update()
    {
        DetectCollision();
    }
    void DetectCollision() 
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if(hit.Length > 0)
        {
            Debug.Log("We hit the " + hit[0].gameObject.name);

            gameObject.SetActive(false);
        }

        if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) ||
            gameObject.CompareTag(Tags.LEFT_LEG_TAG))
        {
            hit[0].GetComponent<HealthManager>().ApplyDamage(damage);
        }
    }
}
