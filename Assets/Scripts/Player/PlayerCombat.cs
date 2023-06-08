using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Player _player;
    private GameController _gameController;
    private ControlSettings _controlSettings;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
        _controlSettings = GameObject.FindWithTag("GameManager").GetComponent<ControlSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_controlSettings.AttackKey))
        {
            _player.UseAttack();
        }
    }
}
