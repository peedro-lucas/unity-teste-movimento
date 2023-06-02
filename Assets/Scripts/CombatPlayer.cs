using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour
{
    public GameObject hitBox;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        hitBox.SetActive(false);
    }

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            StartCoroutine("AttackCorrotina");
        }
    }

    IEnumerator AttackCorrotina()
    {
        PaladinController.velocidade = 0f;
        hitBox.SetActive(true);
        yield return new WaitForSeconds(2f);
        hitBox.SetActive(false);
        PaladinController.velocidade = 5f;
    }
}
