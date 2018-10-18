using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseState : StateMachineBehaviour
{

    Zombie zombie;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Chasing...");
        if (zombie == null)
        {
            zombie = animator.transform.gameObject.GetComponent<Zombie>();
        }

        zombie.nav.speed = zombie.chaseSpeed;
        zombie.nav.isStopped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (zombie.targetGO)
        {
            zombie.nav.destination = zombie.targetGO.transform.position;
            zombie.PlaceMarker(zombie.targetGO.transform.position);

            if (Vector3.Distance(zombie.transform.position, zombie.targetGO.transform.position) < zombie.attackRange)
            {
                zombie.animator.SetTrigger("PlayerInAttackRange");
            }
        }
        else
        {
            zombie.animator.SetBool("PlayerInChaseRange", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
