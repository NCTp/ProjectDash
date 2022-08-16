using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour {
    public float startTimer;
    private float timer;
    private Enemy enemy;
    private GameObject finalSpot;
    private float speed = 3f;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        enemy = GameObject.FindGameObjectWithTag("MagicianBoss").GetComponent<Enemy>();
        finalSpot = GameObject.FindGameObjectWithTag("FinalSpot");
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(timer<=0)
        {
            animator.SetTrigger("Run");
            timer = startTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if(enemy.health <= 2)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, finalSpot.transform.position, speed * Time.deltaTime);
            animator.SetTrigger("FinalAttack");
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
