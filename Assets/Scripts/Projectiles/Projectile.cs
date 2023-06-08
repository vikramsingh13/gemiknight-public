using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{
    private bool _isFired = false;
    private float _projectileSpeed = 10f;
    private float _projectileRange = 2f;
    private Vector3 _currentPosition;
    private Vector3 _initialPosition;
    public float _moveDistance;
    private Vector3 targetDirection;

    public virtual bool IsFired
    {
        get { return _isFired; }
        set { _isFired = value; }
    }

    public virtual float ProjectileSpeed
    {
        get { return _projectileSpeed; }
        set { _projectileSpeed = value; }
    }

    public virtual float ProjectileRange
    {
        get { return _projectileRange; }
        set { _projectileRange = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        base.Update();
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
        if (_isFired)
        {
            transform.position += (targetDirection - transform.position).normalized * ProjectileSpeed * Time.deltaTime;
            
            _currentPosition = transform.position;
            _moveDistance = Vector3.Distance(_initialPosition, _currentPosition);

            StartCoroutine(DestroyDelayed(ProjectileRange));
        }
    }

    //stops projectile from being destroyed when game is paused
    private IEnumerator DestroyDelayed(float delay)
    {
        float elapsedTime = 0f;
        while (elapsedTime < delay)
        {
            if (!base.IsPaused)
            {
                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }

        Destroy(gameObject);
    }

    //fires the prefab
    public virtual void Fire()
    {
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
        _isFired = true;
        //calculate current mouse pointer position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        targetDirection = transform.position + (mousePosition - transform.position).normalized * 100f;
    }
}
