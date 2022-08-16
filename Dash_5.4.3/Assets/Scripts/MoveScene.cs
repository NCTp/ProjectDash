using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {
    [SerializeField] private string newLevel;
    public Animator transitionAnim;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine("LoadScene");
        }
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(newLevel);
    }
}
