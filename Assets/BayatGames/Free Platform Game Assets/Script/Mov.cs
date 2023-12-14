using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Mov : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public float jumpHigh;
    public LayerMask whatIsGround;
    public Transform checkGroundPosition;
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float RunningStaminaCost;
    public float ChargeStaminaSpeed;
    private bool isGrounded;
    private float radiusCheck = 0.2f;
    
    Animator animator;

    private Rigidbody2D rb2D;
    private float x;
    private SpriteRenderer SpriteRenderer;
    private bool isSprinting = false;
    private Coroutine StaminaCharge;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(checkGroundPosition.position, radiusCheck, whatIsGround);
        animator.SetFloat("xVelocity", Math.Abs(rb2D.velocity.x));
        animator.SetFloat("yVelocity", rb2D.velocity.y);
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        // Cek apakah tombol Shift ditekan dan karakter berada di tanah
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && Stamina > 0)
        {
            isSprinting = true;
            Stamina -= RunningStaminaCost * Time.deltaTime;
            if(Stamina < 0 ) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if(StaminaCharge != null) StopCoroutine(StaminaCharge);
            StaminaCharge = StartCoroutine(RechargeStamina());

        }
        else
        {
            isSprinting = false;
        }

        // Mengatur kecepatan berdasarkan apakah sedang berlari atau tidak
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        rb2D.velocity = new Vector2(x * currentSpeed * Time.deltaTime, rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jumping();
            animator.SetBool("isJumping", true);
        }

        if (x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if (x < 0)
        {
            SpriteRenderer.flipX = true;
        }
    }

    void Jumping()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHigh);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }

    // INI buat isi stamina
    private IEnumerator RechargeStamina() {
        yield return new WaitForSeconds(1f);

        while(Stamina < MaxStamina) {
            Stamina += ChargeStaminaSpeed / 10f;
            if(Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }

}
