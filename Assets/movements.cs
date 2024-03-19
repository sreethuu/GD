using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public int speed;
    public int score;
    public int health = 4;
    public int jumpforce;
    private Rigidbody2D rigidbody;
    public Text scoreText;
    public AudioSource jumpSound;
    public AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        rigidbody = GetComponent<Rigidbody2D>();
        scoreText.text = "Score -" + score.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
            jumpSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D colloider)
    {
        if (colloider.gameObject.tag == "coin")
        {
            score++;
            coinSound.Play();
            scoreText.text = "Score -" + score.ToString();
            Destroy(colloider.gameObject);
        }
        else if(colloider.gameObject.tag == "spike")
        {
            health--;
        }
    }
    void jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
    }
}

