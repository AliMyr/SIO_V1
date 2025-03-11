using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Joystick joystick;
    private CharacterController controller;
    private Animator animator;

    public bool joystickActive = false;
    public LayerMask enemyLayer;
    public float enemySearchRadius = 10f;

    private Vector3 lastMoveDirection = Vector3.forward;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 moveDirection = GetInputDirection();
        if (moveDirection.magnitude > 0.1f)
            lastMoveDirection = moveDirection.normalized;

        moveDirection.y -= 9.81f * Time.deltaTime;

        float speed = moveDirection.magnitude;

        animator.SetFloat("moveSpeed", Mathf.Lerp(animator.GetFloat("moveSpeed"), speed, Time.deltaTime * 10));
  
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        

        RotateCharacter();
    }

    private Vector3 GetInputDirection()
    {
        float horizontal = joystickActive ? joystick.Horizontal : Input.GetAxis("Horizontal");
        float vertical = joystickActive ? joystick.Vertical : Input.GetAxis("Vertical");
        return Vector3.ClampMagnitude(new Vector3(horizontal, 0, vertical), 1);
    }

    private void RotateCharacter()
    {
        Transform closestEnemy = GetClosestEnemy();
        Vector3 targetDirection;

        targetDirection = (closestEnemy.position - transform.position).normalized;

        targetDirection = lastMoveDirection;


        targetDirection.y = 0;
        if (targetDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
    }

    private Transform GetClosestEnemy()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, enemySearchRadius, enemyLayer);
        Transform closest = null;
        float minDistance = float.MaxValue;

        foreach (Collider enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy.transform;
            }
        }

        return closest;
    }
}
