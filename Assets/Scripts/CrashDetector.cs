using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    CircleCollider2D playerHead;
 
    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }  
 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider))
        {
            crashEffect.Play();
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene() 
    {
        SceneManager.LoadScene(0);
    }
}
