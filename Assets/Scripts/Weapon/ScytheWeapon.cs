using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    private const string ANIM_PARM_IS_STTACK = "IsAttack";
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_IS_STTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.ENEMY)
        {
            //碰撞到敌人
            Debug.Log("Trigger with " + other.name);

            other.gameObject.GetComponent<Enemy>().TakeDamage(attackValue);
        }
    }

}
