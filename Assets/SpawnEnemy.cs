using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private Transform player;
    TargetDetector targetDetector;
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnFadeOut, OnFadeIn;
    
    bool doneFading = false;
    Animator weaponAnimator;

    [SerializeField]public EnemyArea enemyArea;
    [SerializeField]public EnemyArea2 enemyArea2;
     [SerializeField]public EnemyArea3 enemyArea3;

     [SerializeField]public EnemyArea4 enemyArea4;
      [SerializeField]public EnemyArea5 enemyArea5;
    [SerializeField] public GameObject thisGameObject;

    Rigidbody2D rb;
   

    bool enemyFound = true;
    Transform Enemy;
    public bool isFading = false;
    Animator animator;

    [SerializeField] public float randomRangeX = 5f;
    [SerializeField] public float randomRangeY = 5f;

    // Start is called before the first frame update
    bool isChangingPosition = false;
    void Start()
    {
       
        targetDetector = GameObject.FindGameObjectWithTag("Detector").GetComponent<TargetDetector>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Transform weaponParents = transform.Find("WeaponParent");

        
        

        weaponAnimator = weaponParents.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (!isFading && enemyArea != null)
        {
            StartCoroutine(Fade());
        }

        if (!isFading && enemyArea2 != null)
        {
            StartCoroutine( Fade2());
        }

        if (!isFading && enemyArea3 != null)
        {
            StartCoroutine( Fade3());
        }

        if (!isFading && enemyArea4 != null)
        {
            StartCoroutine( Fade4());
        }

        if (!isFading && enemyArea5 != null)
        {
            StartCoroutine( Fade5());
        }
    }

    public IEnumerator Fade()
    {
        
        float distance = Vector2.Distance(player.position, transform.position);
        float wait = 0.3f;
       

        if (distance > enemyArea.Detector && !isFading && !isChangingPosition && doneFading == false && enemyArea != null )
        {
            
            isFading = true;
            doneFading = false;
            OnMovementInput?.Invoke(Vector2.zero);
            yield return new WaitForSeconds(wait);
            animator.SetBool("FadeOut", true);
            weaponAnimator.SetBool("Fading", true);
            yield return new WaitForSeconds(wait);
            OnFadeOut?.Invoke();

            // Change position for each enemy in the array
            enemyArea.ChangeEnemyPositionRandomly();
             
             yield return new WaitForSeconds(2);
            doneFading =true;
             
            isFading = false;
            isChangingPosition = true;
            doneFading =true;
        }

        if (distance < enemyArea.Detector && !isFading && isChangingPosition &&doneFading==true&& enemyArea != null )
        {
            wait = 0f;
            isFading = true;
             doneFading =true;
            animator.SetBool("FadeOut", false);
            weaponAnimator.SetBool("Fading", false);
            weaponAnimator.SetTrigger("Iddling");
            yield return new WaitForSeconds(wait);
            OnFadeIn?.Invoke();
            isFading = false;
            isChangingPosition = false;
             doneFading =false;
        }

        

    }


public IEnumerator Fade2(){

    float distance = Vector2.Distance(player.position, transform.position);
        float wait = 0.3f;
       
        if (distance > enemyArea2.Detector && !isFading && !isChangingPosition && doneFading == false &&enemyArea2 != null  )
        {
            isFading = true;
            doneFading =false;
            OnMovementInput?.Invoke(Vector2.zero);
            yield return new WaitForSeconds(wait);
            animator.SetBool("FadeOut", true);
            weaponAnimator.SetBool("Fading", true);
            
            yield return new WaitForSeconds(wait);
            OnFadeOut?.Invoke();
            enemyArea2.ChangeEnemyPositionRandomly();
            yield return new WaitForSeconds(2);
            doneFading =true;
            // Change position for each enemy in the array
            
             
            isFading = false;
            isChangingPosition = true;
        }

        if (distance < enemyArea2.Detector && !isFading && isChangingPosition && doneFading ==true && enemyArea2 != null )
        {
            wait = 0f;
            isFading = true;
            doneFading =true;
            animator.SetBool("FadeOut", false);
            weaponAnimator.SetBool("Fading", false);
            weaponAnimator.SetTrigger("Iddling");
            yield return new WaitForSeconds(wait);
            OnFadeIn?.Invoke();
            isFading = false;
            isChangingPosition = false;
            doneFading = false;
        }
    }

    public IEnumerator Fade3(){

    float distance = Vector2.Distance(player.position, transform.position);
        float wait = 0.3f;
       
        if (distance > enemyArea3.Detector && !isFading && !isChangingPosition && doneFading==false && enemyArea3 != null  )
        {
            isFading = true;
             doneFading = false;
            OnMovementInput?.Invoke(Vector2.zero);
            yield return new WaitForSeconds(wait);
            animator.SetBool("FadeOut", true);
            weaponAnimator.SetBool("Fading", true);
            yield return new WaitForSeconds(wait);
            OnFadeOut?.Invoke();
             enemyArea3.ChangeEnemyPositionRandomly();
             yield return new WaitForSeconds(2);
            doneFading = true;
            // Change position for each enemy in the array
           
             
            isFading = false;
            isChangingPosition = true;
        }

        if (distance < enemyArea3.Detector && !isFading && isChangingPosition && doneFading == true && enemyArea3 != null )
        {
            wait = 0f;
            isFading = true;
            doneFading =true;
            animator.SetBool("FadeOut", false);
            weaponAnimator.SetBool("Fading", false);
            weaponAnimator.SetTrigger("Iddling");
            yield return new WaitForSeconds(wait);
            OnFadeIn?.Invoke();
            isFading = false;
            isChangingPosition = false;
            doneFading =false;
        }
    }

    public IEnumerator Fade4(){

    float distance = Vector2.Distance(player.position, transform.position);
        float wait = 0.3f;
        if (distance > enemyArea4.Detector && !isFading && !isChangingPosition && doneFading ==false &&enemyArea4 != null  )
        {
            isFading = true;
            doneFading =false;
            OnMovementInput?.Invoke(Vector2.zero);
            yield return new WaitForSeconds(wait);
            animator.SetBool("FadeOut", true);
            weaponAnimator.SetBool("Fading", true);
            yield return new WaitForSeconds(wait);
            OnFadeOut?.Invoke();

            // Change position for each enemy in the array
            enemyArea4.ChangeEnemyPositionRandomly();
             yield return new WaitForSeconds(2);
            doneFading = true;
            isFading = false;
            isChangingPosition = true;
        }

        if (distance < enemyArea4.Detector && !isFading && isChangingPosition && doneFading ==true && enemyArea4 != null )
        {
            wait = 0f;
            isFading = true;
            doneFading = true;
            animator.SetBool("FadeOut", false);
            weaponAnimator.SetBool("Fading", false);
            weaponAnimator.SetTrigger("Iddling");
            yield return new WaitForSeconds(wait);
            OnFadeIn?.Invoke();
            isFading = false;
            isChangingPosition = false;
            doneFading =false;
        }
    }




     public IEnumerator Fade5(){

    float distance = Vector2.Distance(player.position, transform.position);
        float wait = 0.3f;
        if (distance > enemyArea5.Detector && !isFading && !isChangingPosition && doneFading ==false &&enemyArea5 != null  )
        {
            isFading = true;
            doneFading =false;
            OnMovementInput?.Invoke(Vector2.zero);
            yield return new WaitForSeconds(wait);
            animator.SetBool("FadeOut", true);
            weaponAnimator.SetBool("Fading", true);
            yield return new WaitForSeconds(wait);
            OnFadeOut?.Invoke();

            // Change position for each enemy in the array
            enemyArea5.ChangeEnemyPositionRandomly();
             yield return new WaitForSeconds(2);
            doneFading = true;
            isFading = false;
            isChangingPosition = true;
        }

        if (distance < enemyArea5.Detector && !isFading && isChangingPosition && doneFading ==true && enemyArea5 != null )
        {
            wait = 0f;
            isFading = true;
            doneFading = true;
            animator.SetBool("FadeOut", false);
            weaponAnimator.SetBool("Fading", false);
            weaponAnimator.SetTrigger("Iddling");
            yield return new WaitForSeconds(wait);
            OnFadeIn?.Invoke();
            isFading = false;
            isChangingPosition = false;
            doneFading =false;
        }
    }
    
}

