using UnityEngine;
using UnityEngine.UI;

public class ArrowMinimap : MonoBehaviour
{
    GameObject player;
    [SerializeField] Image image;
    RectTransform rectTransform;

    Vector2 playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = new Vector2(player.transform.position.x, player.transform.position.z);
        rectTransform.localPosition = (playerTransform);
        
    }
}
