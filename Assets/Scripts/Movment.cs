using UnityEngine;

public class Movment : MonoBehaviour
{
    Animator animator;
    float speed;
    Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("SwordEquip", false);
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //animator.SetBool("isRunning", 

        speed = Vector3.Distance(oldPosition, transform.position) * 100f;
        oldPosition = transform.position;

        animator.SetFloat("Speed", speed);

        //Debug.Log("Speed: " + speed.ToString("F2"));

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();

        }
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
