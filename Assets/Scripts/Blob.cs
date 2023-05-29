using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blob : MonoBehaviour
{
    protected Rigidbody2D rb;

    private float _moveSpeed = 5f;
    private float _currentHealth = 1000f;
    private float _maxHealth = 1000f;
    private float _directionChangeInterval = 100f;
    private float _lastDirectionUpdate = 0f;
    private Vector2 _initialPosition;
    private Vector2 _currentPosition;
    private float _moveDistanceLimit = 5f;
    private float _moveDistance;
    private Slider _healthBar;

    public virtual float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    public virtual float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public virtual float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public virtual float DirectionChangeInterval
    {
        get { return _directionChangeInterval; }
        set { _directionChangeInterval = value; }
    }

    public virtual float LastDirectionUpdate
    {
        get { return _lastDirectionUpdate; }
        set { _lastDirectionUpdate = value; }
    }

    public virtual Vector2 InitialPosition
    {
        get { return _initialPosition; }
        set { _initialPosition = value; }
    }

    public virtual Vector2 CurrentPosition
    {
        get { return _currentPosition; }
        set { _currentPosition = value; }
    }

    public virtual float MoveDistanceLimit
    {
        get { return _moveDistanceLimit; }
        set { _moveDistanceLimit = value; }
    }

    public virtual float MoveDistance
    {
        get { return _moveDistance; }
        set { _moveDistance = value; }
    }

    public virtual Slider HealthBar
    {
        get { return _healthBar; }
        set { _healthBar = value; }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _currentPosition = transform.position;
        HealthCheck();
        UpdateDistance();
    }

    public virtual Vector2 CalculateMovementVector()
    {
        //random movement vector
        Vector2 randomMovement = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        randomMovement.Normalize();
        return randomMovement;
    }

    //when movement limit is reached or hits a rigidbody it's not supposed to hit
    public virtual Vector2 GetOriginMovementVector(Vector2 moveVector)
    {
        Vector2 originMovement = (InitialPosition - CurrentPosition).normalized * moveVector.magnitude;
        return originMovement;
    }

    //updates the distance between current and origin/initial
    private void UpdateDistance()
    {
        float deltaX = _currentPosition.x - _initialPosition.x;
        float deltaY = _currentPosition.y - _initialPosition.y;
        _moveDistance = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    //helper to check for health every update
    private void HealthCheck()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(HealthBar.gameObject);
            Destroy(this.gameObject);
        }
    }

    //reduces health for now
    public void ReduceHealth(float hitStrength)
    {
        if(CurrentHealth - hitStrength > 0)
        {
            CurrentHealth -= hitStrength;
        } else
        {
            CurrentHealth = 0;
        }
        Debug.Log("current health " +  CurrentHealth);
        OnHealthChange();
    }

    //sets the health bar slider as the percentage of health left
    public virtual void OnHealthChange()
    {
        HealthBar.value = CurrentHealth / MaxHealth;
    }
}
