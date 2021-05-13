using UnityEngine;

public class ItemHighlighter : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            this.transform.localScale = new Vector3(1.1f,1.1f,1.1f);
        }
    }
    public void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            this.transform.localScale = new Vector3(0.843f,0.843f,0.843f);
        }
    }
}
