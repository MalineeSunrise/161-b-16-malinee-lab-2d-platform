using UnityEngine;


public class Ant : Enemy
{
    [SerializeField] Vector2 velocity;
    public Transform[] MovePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.intialize(50);

        DamageHit = 20;
        velocity = new Vector2(-1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        //Debug.Log("FixUpdate" + Time.fixedDeltaTime);

        if (velocity.x < 0 && rb.position.x <= MovePoint[0].position.x)
        {
            Flip();
        }
        //move right และเกินขอบขวา
        if (velocity.x > 0 && rb.position.x >= MovePoint[1].position.x)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    public void Flip()
    {
        velocity.x *= -1; //change direction of movement
                          //Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
