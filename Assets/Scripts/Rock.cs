using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb;
    public Vector2 force;

    private bool hasHit = false;

    public override void Move()
    {
        rb.AddForce(force);
    }

    public override void OnHitWith(Character obj)
    {
        if (obj is Player)
        {
            obj.TakeDamage(this.damage);
            hasHit = true; 
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = 25;
        force = new Vector2(GetShootDirection() * 180, 400);
        Move();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

