using UnityEngine;

public class Upgrade : MonoBehaviour
{
    Animator animator;
    public GameObject AnimatorRef;
    BoxCollider boxcolider;
    BoxCollider doorColider;
    ParticleSystem particlesystem;

    public Color ParticleColor1;
    public Color ParticleColor2;

    bool used;
    bool Epressed;
    // Start is called before the first frame update
    void Start()
    {
        boxcolider = GetComponent<BoxCollider>();
        animator = AnimatorRef.GetComponent<Animator>();
        particlesystem = GetComponent<ParticleSystem>();
        Epressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Epressed = true;
        }
        else Epressed = false;
    }

   
    public void OnTriggerStay(Collider obiect)
    {
        if (obiect.gameObject.CompareTag("Player"))
        {
            if (Epressed == true && used == false)
            {
                Debug.Log("LevelUp");
                animator.SetTrigger("Upgrade");

                particlesystem.Pause();
                used = true;
            }
            else if(Epressed == true && used == true)
            {
                Debug.Log("Already Used");
               
            }
        }
        if(gameObject.CompareTag("Doors") && obiect.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi");
        }
    }
    
}
