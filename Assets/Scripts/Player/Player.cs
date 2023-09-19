using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rig;
    public Animator anim;
    public Vector2 friction = new Vector2(.1f, 0);



    [Header("Animations Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;


    [Header("Animations Player")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;
    

    [Header("Speed Setup")]
    public float speed; 
    public float speedRun;
    private float _currentSpeed;
    private bool isRunning;

    
    [Header("Jump Setup END Jump Collision Check")] 
    public float forceJump;
    public Collider2D collider2dJump;
    public float distanceToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;
    public ParticleSystem dustVFX;
    public AudioSource audioSourceJump;


    [Header("Health Player")]
    public HealthBase healthBase;
    public GameObject gameOver;


    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.onKill += OnPlayerKill;
        }

        if (collider2dJump != null)
        {
            distanceToGround = collider2dJump.bounds.extents.y;
        }

        if(dustVFX != null)
        {
            if (VFXManager.instance != null)
            {
                VFXManager.instance.PlayerVFXByType(VFXManager.VFXType.PlayerDust, transform.position);
            }
        }
    }

    private bool IsGrounded()//TEM UM BUG NO PULO PARA RESOLVER
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.yellow, distanceToGround * spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround * spaceToGround);
    }


    void OnPlayerKill()
    {
       healthBase.onKill -= OnPlayerKill;
       anim.SetTrigger(triggerDeath);
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }



    private void Update()
    {
        IsGrounded();
        PlayerMoviment();
        PlayerJump();
    }

    private void PlayerMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
            anim.speed = 2;
        }
        else
        {
            _currentSpeed = speed;
            anim.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2(-_currentSpeed, rig.velocity.y);
           if(rig.transform.localScale.x != -1)
           {
                rig.transform.DOScaleX(-1, playerSwipeDuration);
           }
            anim.SetBool(boolRun, true);
            Debug.Log("Esquerda");

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2(_currentSpeed, rig.velocity.y);
            if (rig.transform.localScale.x != 1)
            {
                rig.transform.DOScaleX(1, playerSwipeDuration);
            }
            anim.SetBool(boolRun, true);
            Debug.Log("Direita");
            
        }
        else
        {
            anim.SetBool(boolRun, false);
        }


        if(rig.velocity.x >= 0)
        {
            rig.velocity += friction;
        }
        else if(rig.velocity.x <= 0)
        {
            rig.velocity -= friction;
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            audioSourceJump.Play();
            rig.velocity = Vector2.up * forceJump;
            rig.transform.localScale = Vector2.one;

            DOTween.Kill(rig.transform);

            PlayerScaleJump();
            PlayerJumpVFX();
            Debug.Log("Pulou");
        }
    }

    private void PlayerJumpVFX()
    {
        
        if (jumpVFX != null)
        {
            //VFXManager.instance.PlayerVFXByType(VFXManager.VFXType.Jump, transform.position);
            jumpVFX.Play();
        }
    }


    private void PlayerScaleJump()
    {
        rig.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        rig.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
       

    }

    public void DestroyMe()
    {
        Destroy(gameObject);
        gameOver.SetActive(true);


    }
}
