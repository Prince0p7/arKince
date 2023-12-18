using UnityEngine;
using UnityEngine.SceneManagement;

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
    void Update()
    {
        MenuInput();
    }
    private void MenuInput()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
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