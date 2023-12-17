using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput _input; // Input Action Reference
    public static InputManager Instance;

    void Awake()
    {
        _input = new PlayerInput();

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    
    public Vector2 MoveInput()
    {
        return _input.Player.Move.ReadValue<Vector2>();
    }
    public bool Action()
    {
        return _input.Player.Action.triggered;
    }
}