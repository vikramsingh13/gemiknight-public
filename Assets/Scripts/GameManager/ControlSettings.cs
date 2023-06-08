using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSettings : MonoBehaviour
{
    // Movement Keys
    [SerializeField] private KeyCode _upKey = KeyCode.W;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _downKey = KeyCode.S;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;

    // Action Keys
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;

    // Number Keys
    [SerializeField] private KeyCode _key1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _key2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode _key3 = KeyCode.Alpha3;
    [SerializeField] private KeyCode _key4 = KeyCode.Alpha4;

    // Mouse Buttons
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _mouseRightButton = KeyCode.Mouse1;

    // Other Keys
    [SerializeField] private KeyCode _escapeKey = KeyCode.Escape;
    [SerializeField] private KeyCode _qKey = KeyCode.Q;
    [SerializeField] private KeyCode _eKey = KeyCode.E;
    [SerializeField] private KeyCode _rKey = KeyCode.R;
    [SerializeField] private KeyCode _fKey = KeyCode.F;
    [SerializeField] private KeyCode _tKey = KeyCode.T;

    // Getters and Setters for Movement Keys
    public KeyCode UpKey { get { return _upKey; } set { _upKey = value; } }
    public KeyCode LeftKey { get { return _leftKey; } set { _leftKey = value; } }
    public KeyCode DownKey { get { return _downKey; } set { _downKey = value; } }
    public KeyCode RightKey { get { return _rightKey; } set { _rightKey = value; } }

    // Getters and Setters for Action Keys
    public KeyCode JumpKey { get { return _jumpKey; } set { _jumpKey = value; } }
    public KeyCode SprintKey { get { return _sprintKey; } set { _sprintKey = value; } }

    // Getters and Setters for Number Keys
    public KeyCode Key1 { get { return _key1; } set { _key1 = value; } }
    public KeyCode Key2 { get { return _key2; } set { _key2 = value; } }
    public KeyCode Key3 { get { return _key3; } set { _key3 = value; } }
    public KeyCode Key4 { get { return _key4; } set { _key4 = value; } }

    // Getters and Setters for Mouse Buttons
    public KeyCode AttackKey { get { return _attackKey; } set { _attackKey = value; } }
    public KeyCode MouseRightButton { get { return _mouseRightButton; } set { _mouseRightButton = value; } }

    // Getters and Setters for Other Keys
    public KeyCode EscapeKey { get { return _escapeKey; } set { _escapeKey = value; } }
    public KeyCode QKey { get { return _qKey; } set { _qKey = value; } }
    public KeyCode EKey { get { return _eKey; } set { _eKey = value; } }
    public KeyCode RKey { get { return _rKey; } set { _rKey = value; } }
    public KeyCode FKey { get { return _fKey; } set { _fKey = value; } }
    public KeyCode TKey { get { return _tKey; } set { _tKey = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
