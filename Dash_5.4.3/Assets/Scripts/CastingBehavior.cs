using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingBehavior : StateMachineBehaviour {
    public GameObject[] magics;
    private int randomMagic;
    public float startTimer;
    private float timer;
    private GameObject muzzle;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timer = startTimer;
        randomMagic = Random.Range(0, magics.Length);
        muzzle = GameObject.FindGameObjectWithTag("Muzzle");
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (timer <= 0)
        {
            animator.SetTrigger("Idle");
            timer = startTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        Instantiate(magics[randomMagic], muzzle.transform.position, muzzle.transform.rotation);
        randomMagic = Random.Range(0, magics.Length);


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
