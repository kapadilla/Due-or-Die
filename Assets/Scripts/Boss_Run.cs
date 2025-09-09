using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public float attackCooldown = 2f;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    float lastAttackTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        lastAttackTime = 0;

        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player GameObject is tagged as 'Player'.");
        }
        else
        {
            Debug.Log("Player found: " + player.name);
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on the boss.");
        }
        else
        {
            Debug.Log("Rigidbody2D found on the boss.");
        }

        if (boss == null)
        {
            Debug.LogError("Boss script not found on the boss.");
        }
        else
        {
            Debug.Log("Boss script found on the boss.");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null || rb == null || boss == null)
        {
            Debug.LogError("Missing component references in Boss_Run.OnStateUpdate.");
            return;
        }

        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        //Debug.Log("Boss moving to player at position: " + player.position);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                animator.SetTrigger("attack");
                lastAttackTime = Time.time;
                Debug.Log("Boss attacking player");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }
}
