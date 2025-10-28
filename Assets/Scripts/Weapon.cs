using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;

    public IShootable Shooter;

    public abstract void Move();

    public abstract void OnHitWith(Character character);

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void InitWeapon(int newDamage, IShootable newShooter)
    {
        damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        float value = Shooter.ShootPoint.position.x -
            Shooter.ShootPoint.parent.position.x;
        if (value > 0)
            return 1;
        else return -1;
    }

    private void OntriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            OnHitWith(character);
            Destroy(this.gameObject, 5f);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
