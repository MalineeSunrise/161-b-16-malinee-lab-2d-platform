using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }

    [field: SerializeField] public Transform ShootPoint { get; set; }

    [SerializeField] float attackRange;
    public Player player;

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.intialize(50);
        DamageHit = 30;

        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0;
        ReloadTime = 2f;
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

        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0;
        }
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

}
