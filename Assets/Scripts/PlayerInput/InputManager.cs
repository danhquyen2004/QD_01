using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance {  get { return instance; } }
    

    private float horizontal;
    public float Horizontal {  get { return horizontal; } }

    private bool jump;
    public bool Jump { get { return jump; } }

    private bool normalAtk;
    public bool NormalAtk { get {  return normalAtk; } }

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        HorizontalInput();
        JumpInput();
        NormalAtkInput();
    }
    private void HorizontalInput()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    private void JumpInput()
    {
        jump = Input.GetKeyDown(KeyCode.Space);
    }
    private void NormalAtkInput() 
    {
        normalAtk = Input.GetKeyDown(KeyCode.J);
    }
}
