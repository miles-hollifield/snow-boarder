using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    CircleCollider2D playerHead;
    bool hasCrashed = false;
 
    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }  
 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX, 0.5f);
            Invoke("ReloadScene", loadDelay);
        }
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(0);
    }
}
