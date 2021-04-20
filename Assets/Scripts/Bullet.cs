using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D bulletRigidbody;
    public float speed = 20f;
    public GameObject explosionEffect;
    [HideInInspector] public bool viradoDireita = true;

    private void Start() {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce (transform.forward * speed);

        if (!viradoDireita)
        {
            viradoDireita = true;
            Flip();
        }
    }

    private void Update() {
        destroyPorTempo();
    }

    private void FixedUpdate()
    {
        CheckDirection();

       // float translationY = 0;
       /*
        float translationX = Input.GetAxis("Horizontal") * speed;

        if (translationX > 0 && !viradoDireita)
        {
            Flip();
        }
        else if (translationX < 0 && viradoDireita)
        {
            Flip();
        }
       */
    }

    public void CheckDirection()
    {
        if((viradoDireita) && bulletRigidbody.velocity.x < 0)
        {
            Flip();
        }
        else if((!viradoDireita) && bulletRigidbody.velocity.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector2 escala = new Vector2();
        escala = gameObject.transform.localScale;
        escala.x *= -1;
        gameObject.transform.localScale = escala;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("COLIDIU!" + collision.name);
        Destroy(gameObject);
        Destroy(Instantiate(explosionEffect, transform.position, transform.rotation),2);
    }

    private void destroyPorTempo() {
        Destroy(gameObject, 1f);
    }

}
