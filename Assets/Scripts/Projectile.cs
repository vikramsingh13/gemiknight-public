using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
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
        if (_isFired)
        {
            transform.position += (targetDirection - transform.position).normalized * ProjectileSpeed * Time.deltaTime;
            
            _currentPosition = transform.position;
            _moveDistance = Vector3.Distance(_initialPosition, _currentPosition);

            Destroy(gameObject, 1);
        }
    }

    //fires the prefab
    public virtual void Fire()
    {
        _isFired = true;
        Debug.Log(" Projectile was fired! ");
        //calculate current mouse pointer position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        targetDirection = transform.position + (mousePosition - transform.position).normalized * 100f;
    }
}
