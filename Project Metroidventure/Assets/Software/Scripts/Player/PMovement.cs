using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float runSpeed = 15f;
    [SerializeField] private float dashForce = 65f;
    [SerializeField] private float dashCooldown = 3f;

    public Text StamNumber;

    private float horizontal, vertical;
    private float currentSpeed;
    private float lastDashTime;

    private bool isFacingRight = true;
    private bool isDashing = false;
    private bool hasStamina = true;

    public Image staminaBar;
    public GameObject StaminaBarCanvasimsi;
    public float stamina, maxStamina;
    public float dashStamCost, runStamCost;
    public float staminaCharge;

    Coroutine recharge;
    Coroutine hideCanvas;

    Rigidbody2D rb;

    private void Start()
    {
        textYenile();
        StaminaBarCanvasimsi.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        lastDashTime = -dashCooldown;
    }
    
    private void Update()
    {
        ReceiveInput();
        Flip();

        if (Input.GetKey(KeyCode.LeftShift) && hasStamina)
        {
            StaminaBarCanvasimsi.SetActive(true);
            currentSpeed = runSpeed;

            stamina -= runStamCost * Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                hasStamina = false;
            }
            staminaBar.fillAmount = stamina / maxStamina;

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());
        }
        else
        {
            currentSpeed = speed;
            if (hideCanvas == null)
            {
                hideCanvas = StartCoroutine(HideCanvasAfterDelay(1.2f));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown && stamina >= dashStamCost)
        {
            Dash();
        }
        textYenile();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            Movement();
        }
    }

    void Movement()
    {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb.velocity = movement * currentSpeed;
    }

    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void ReceiveInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Dash()
    {
        isDashing = true;
        lastDashTime = Time.time;

        Vector2 dashDirection = new Vector2(horizontal, vertical).normalized;
        if (dashDirection == Vector2.zero) 
        {
            dashDirection = isFacingRight ? Vector2.right : Vector2.left;
        }

        rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);

        stamina -= dashStamCost;
        if (stamina < 0) stamina = 0;
        staminaBar.fillAmount = stamina / maxStamina;

        if(recharge != null) StopCoroutine(recharge);
        recharge = StartCoroutine(RechargeStamina());

        StaminaBarCanvasimsi.SetActive(true);

        StartCoroutine(EndDash());
    }

    private void textYenile()
    {
        StamNumber.text = ((int)stamina) + " / " + ((int)maxStamina);
    }


    IEnumerator EndDash()
    {
        yield return new WaitForSeconds(0.1f);
        isDashing = false; 
    }
    IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);
        while (stamina < maxStamina)
        {
            stamina += staminaCharge / 10f;
            if (stamina > maxStamina) stamina = maxStamina;
            staminaBar.fillAmount = stamina / maxStamina;
            yield return new WaitForSeconds(.1f);
            hasStamina = true;
        }
        StaminaBarCanvasimsi.SetActive(false);
    }
    IEnumerator HideCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StaminaBarCanvasimsi.SetActive(false);
    }
}
