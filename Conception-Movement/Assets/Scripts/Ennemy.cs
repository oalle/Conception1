using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public AudioClip deathClip;
    public AudioClip moveClip;
    AudioSource audioSource;

    private Animator anim;
    private bool isAlive = true;
    private bool movingRight = false;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", true);
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true) 
            {

                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                StartCoroutine(Movement());
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                StartCoroutine(Movement());

            }
        }
    }

    IEnumerator Movement()
    {
        anim.SetBool("isMoving", false);   
        anim.Play("Ennemy_idle");

        speed = 0;
        transform.Translate(Vector2.right * speed * Time.deltaTime);


        float counter = 0;
        float waitTime = anim.GetCurrentAnimatorStateInfo(0).length;

        //Now, Wait until the current state is done playing
        while (counter < (waitTime))
        {
            counter += Time.deltaTime;
            yield return null;
        }
        speed = 2;
        AudioSource.PlayClipAtPoint (moveClip, transform.position);
    }

    IEnumerator Death()
    {
        anim.SetBool("isMoving", false);
        anim.SetBool("isAttack", true);
        anim.SetBool("isAlive", false);

            anim.Play("Ennemy_die");

            speed = 0;
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            float counter = 0;
            float waitTime = anim.GetCurrentAnimatorStateInfo(0).length;

            AudioSource.PlayClipAtPoint (deathClip, transform.position);

            //Now, Wait until the current state is done playing
            while (counter < 5*(waitTime))
            {
                counter += Time.deltaTime;
                yield return null;
            }

            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals ("Player_attack"))
        {
            StartCoroutine(Death());
        }
    }
}
