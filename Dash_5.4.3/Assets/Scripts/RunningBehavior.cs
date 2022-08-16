using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBehavior : StateMachineBehaviour {
    public float speed;
    

    private PatrolSpots patrol;
    private int randomSpot;
    private int randomPattern;
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        patrol = GameObject.FindGameObjectWithTag("PatrolSpots").GetComponent<PatrolSpots>();
        randomSpot = Random.Range(0, patrol.patrolPoints.Length);
        randomPattern = Random.Range(0, 2);
	
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrol.patrolPoints[randomSpot].position, speed * Time.deltaTime);
        if(Vector2.Distance(animator.transform.position,patrol.patrolPoints[randomSpot].position)<0.2f)
        {
            if(randomPattern ==1)
            {
                animator.SetTrigger("Summon");
                randomPattern = Random.Range(0, 2);
            }
            else if(randomPattern == 0)
            {
                animator.SetTrigger("Cast");
                randomPattern = Random.Range(0, 2);
            }
           

            
        }
	
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
