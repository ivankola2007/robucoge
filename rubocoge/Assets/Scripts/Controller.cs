using UnityEngine;
using UnityEngine.Input

public class Controller
{
    [SerializeField]
    private PlayerInputActions inputActions;
    [SerializeField]
    private CharacterController cController;
    [SerializeField]
    private Animator animator;

    privte Vector2 movementInput;
    private Vector3 currentMovement;
    private Quanternition rotateDir;
    private bool isRun;
    private bool isWalk
    
    private voif OnMovementAction(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        currentMovement.x = movementInput.x;
        currentMovement.z = movementInput.y;
        isWalk = movementInput.x !=0 || movementInput.y !=0;
    }
}
