using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;

    private Animator m_animator;

    private bool m_facingRight = true;
    private bool m_onInteractRange = false;
    private bool m_busy = false;
    private float m_movement = 0.0f;

    private InteractableNPC m_currentNPCTarget = null;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessInput();
        if(!m_busy)
            ProcessMovement();
        UpdateAnimator();
    }

    private void ProcessMovement()
    {
        m_movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(m_movement * m_moveSpeed * Time.deltaTime, 0.0f, 0.0f);

        if((m_movement > 0.0f && !m_facingRight) || m_movement < 0.0f && m_facingRight)
        {
            transform.Rotate(0, 180, 0);
            m_facingRight = !m_facingRight;
        }
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_onInteractRange)
        {
            SetPlayerBusy(true);
            m_currentNPCTarget.Interact();
        }
    }

    public void SetPlayerBusy(bool isBusy)
    {
        m_busy = isBusy;
    }

    private void UpdateAnimator()
    {
        if(Mathf.Abs(m_movement) > 0.0f)
        {
            m_animator.SetBool("movement", true);
        }
        else
        {
            m_animator.SetBool("movement", false);
        }
    }

    public void OnInteractRange(bool onInteractRange, InteractableNPC target)
    {
        m_onInteractRange = onInteractRange;
        m_currentNPCTarget = target;
    }
}
