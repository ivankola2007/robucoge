using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Playerinputactions inputActions;
    [SerializeField]
    private CharacterController cController;
    [SerializeField]
    private Animator animator;
    private PhotonView pView;

    private Vector2 movementInput;
    private Vector3 currentMovement;
    private Quaternion rotateDir;
    private bool isRun;
    private bool isWalk;
    private float rotateSpeed;

    private void Awake()
    {
        inputActions = new Playerinputactions();
        inputActions.CharacterController.movement.started += OnMovementAction;
        inputActions.CharacterController.movement.performed += OnMovementAction;
        inputActions.CharacterController.movement.canceled += OnMovementAction;
        inputActions.CharacterController.Run.started +=  OnRun;
        inputActions.CharacterController.Run.canceled +=  OnRun;        
         }

    private void AnimateControl()
    {
        animator.SetBool("isWalk",isWalk);
        animator.SetBool("isWalk",isWalk);
    }
    private void PlayerRotate()
    {
        if (!isWalk) return;
        rotateDir = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(currentMovement), Time.deltaTime * rotateSpeed);
        transform.rotation = rotateDir;
    }
    
    private void OnMovementAction(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        currentMovement.x = movementInput.x;
        currentMovement.z = movementInput.y;
        isWalk = movementInput.x !=0 || movementInput.y !=0;
    }
    private void OnEnable()
    {
        inputActions.CharacterController.Enable();
    }
    private void OnDisable()
    {
        inputActions.CharacterController.Disable();
    }
    private void FixedUpdate()
    {
        cController.Move(currentMovement * Time.fixedDeltaTime);
    }
 private void OnRun(InputAction.CallbackContext context)
 {
 isRun = context.ReadValueAsButton();
 }
    
}
