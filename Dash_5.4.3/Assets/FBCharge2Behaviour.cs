using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBCharge2Behaviour : StateMachineBehaviour {
    private Transform playerPos;
    public float speed;
    public float startChargeTime;

    
    private float chargeTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        chargeTime = startChargeTime;

    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(chargeTime > 0)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position,
            playerPos.position, speed * Time.deltaTime);
            chargeTime -= Time.deltaTime;
        }
        else if(chargeTime <=0)
        {
            animator.SetTrigger("Idle");
            chargeTime = startChargeTime;
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
