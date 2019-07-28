using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D body;

    public float walkingSpeed;
    public float jumpSpeed;
    public int maxJumps;

    private int currentJumps = 0;

    private void Awake()
    {
        trans = transform;
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Handle max amount of jumps
        if (currentJumps > 0 && body.velocity.y == 0)
        {
            currentJumps = 0;
            Debug.Log("You can jump again!");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        { // y-axis movement
            if (currentJumps < maxJumps)
            {
                body.velocity += jumpSpeed * Vector2.up;
                currentJumps++;
            }
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                speed += -walkingSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }


                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherObject = collision.collider.gameObject;
        if (otherObject.tag == "Magnifier")
        {
            var scale = transform.localScale;
            scale.y *= 2;
            transform.localScale = scale;
            //otherObject.SetActive(false);
            //GameObject.Destroy(otherObject);
        }
    }
}
