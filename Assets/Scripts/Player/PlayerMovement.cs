using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D body;

    public float walkingSpeed;
    public float jumpSpeed;
    public int maxJumps;

    private int m_currentJumps = 0;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

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
        if (m_currentJumps > 0 && body.velocity.y == 0)
        {
            m_currentJumps = 0;
            Debug.Log("You can jump again!");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        { // y-axis movement
            if (m_currentJumps < maxJumps)
            {
                body.velocity += jumpSpeed * Vector2.up;
                m_currentJumps++;
            }
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -walkingSpeed;

                if (m_FacingRight)
                {
                    Flip();
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += walkingSpeed;

                if (!m_FacingRight)
                {
                    Flip();
                }
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

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Rotate
        transform.Rotate(0f, 180f, 0f);
    }
}
