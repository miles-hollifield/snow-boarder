using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;
    CapsuleCollider2D playerBoard;

    void Start()
    {
        playerBoard = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerBoard.IsTouching(other.collider))
        {
            dustEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && !playerBoard.IsTouching(other.collider))
        {
            dustEffect.Stop();
        }
    }
}
