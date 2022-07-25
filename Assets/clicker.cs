using UnityEngine;
using UnityEngine.EventSystems;

public class clicker : MonoBehaviour, IPointerClickHandler
{
    public int x;
    public int y;
    public GameObject i;
    public void OnPointerClick(PointerEventData eventData)
    {
        i = GameObject.Find("test");
        i.GetComponent<main>().shot(x,y);
    }   
}
