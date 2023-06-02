using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public GameObject hitbox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Attack");
            agent.isStopped = true;
            
        }

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("attack", true);
        print("dano");
        hitbox.SetActive(false);
    }
}
