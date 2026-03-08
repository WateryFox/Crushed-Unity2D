using UnityEditor.Build.Content;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 6f;
    public bool movingPlatformLeft, movingPlatformRight, isBreakable, isPlaftorm, isSpike;
    private Animator anim;
    void Awake()
    {
        if (isBreakable)
        {
            anim = GetComponent<Animator>();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Awake();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;
        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        }
    }
    void breakableDeactivate()
    {
        Invoke("deactivateGameObject", 0.3f);
    }
    void deactivateGameObject()
    {
        // SoundManager.instance.iceBreakSound();
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isSpike)
            {
                // print("spike");
                collision.transform.position = new Vector2(1000f, 1000f);
                // SoundManager.instance.gameOverSound();
                gameManager.instance.gameOver();
                
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isBreakable)
            {
                // print("break");
                // SoundManager.instance.landSound();
                anim.Play("breaker");
            }
            if (isPlaftorm)
            {
                // print("platform");
                // SoundManager.instance.landSound();
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (movingPlatformLeft)
            {
                // print("movingL");
                collision.gameObject.GetComponent<playerMove>().platformMove(-1f);
            }
            if (movingPlatformRight)
            {
                // print("movingR");
                collision.gameObject.GetComponent<playerMove>().platformMove(1f);
            }
            
        }

    }
}
