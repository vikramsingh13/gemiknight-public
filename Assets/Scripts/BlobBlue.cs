using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BlobBlue : Blob
{
    public float _moveSpeedBlueBlob = 3f;
    public float _maxHealthBlueBlob = 1000f;
    public float _directionChangeIntervalBlueBlob = 500f;
    public Vector2 newMovement;
    public Slider healthBar;

    public override float MoveSpeed
    {
        get { return _moveSpeedBlueBlob; }
        set { _moveSpeedBlueBlob = value; }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        base.MaxHealth = _maxHealthBlueBlob;
        base.HealthBar = healthBar;
        base.DirectionChangeInterval = _directionChangeIntervalBlueBlob * Time.deltaTime;
        GetNewMovement();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        base.DirectionChangeInterval = _directionChangeIntervalBlueBlob * Time.deltaTime;

        transform.Translate(newMovement * MoveSpeed * Time.deltaTime);

        if (base.LastDirectionUpdate > DirectionChangeInterval)
        {
            if (base.MoveDistance > base.MoveDistanceLimit)
            {
                GetOriginMovement();
            } else
            {
                GetNewMovement();
            }
        }

        

        base.LastDirectionUpdate += Time.deltaTime;

    }

    //init newMovement direction and reset LastDirectionUpdate to 0
    private void GetNewMovement()
    {
        newMovement = base.CalculateMovementVector();
        transform.Translate(newMovement * MoveSpeed * Time.deltaTime);
        base.LastDirectionUpdate = 0f;
    }

    //gets the movement vector towards initial/origin of the entity
    //after hitting a boundary or going over move distance limit from origin
    private void GetOriginMovement()
    {
        newMovement = base.GetOriginMovementVector(newMovement);
        transform.Translate(newMovement * MoveSpeed * Time.deltaTime);
        base.LastDirectionUpdate = 0f;
    }
}
