using UnityEngine;
using UnityEngine.UI;
using System;

public class Character : MonoBehaviour
{
    [SerializeField] public float CurrentHealth { get; private set; }
    [SerializeField] private float MaxHp = 100f;

    private float hearlth;
    public float Health
    {
        get { return hearlth; }
        set { hearlth = (value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void intialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialize Health Health : {this.Health}");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage} Current hearlth {Health}");

        IsDead();

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        CurrentHealth = Health;
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else { return false; }
    }

    public float CalculateHealth()
    {
        return Health / MaxHp;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
