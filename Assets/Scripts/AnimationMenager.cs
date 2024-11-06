using UnityEngine;

public class AnimationMenager : MonoBehaviour
{
    //References
    Animator animator;
    GameObject player;
    PlayerMovementTutorial playerMovement;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("SwordEquip", false);
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovementTutorial>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //animator.SetBool("isRunning", 

        

        animator.SetFloat("Speed", playerMovement.speed);

        //Debug.Log("Speed: " + speed.ToString("F2"));

        if (Input.GetKeyUp(KeyCode.F) && animator.GetBool("SwordEquip") == false)
        {
            EquipSword();
            Debug.Log("Dobywasz miecz");

        }
        else
        if (Input.GetKeyUp(KeyCode.F) && animator.GetBool("SwordEquip") == true)
        {
            UnequipSword();
            Debug.Log("Chowasz miecz");

        }
        
        //if(Input.GetKeyUp(KeyCode.Alpha1))
        //{

        //}

    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void EquipSword()
    {
        animator.SetBool("SwordEquip", true);

    }
    public void UnequipSword()
    {
        animator.SetBool("SwordEquip", false);

    }
    public void CastSpell()
    {
        
        
    }
    
}
