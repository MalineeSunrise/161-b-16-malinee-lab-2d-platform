using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] float attackRange;
    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.intialize(50);
        DamageHit = 50;

        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }

    public override void Behavior()
    {
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= attackRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }

    public void Shoot() 
    {
        Debug.Log($"{player.name} shoots rock to the {player.name}");
    }

}
