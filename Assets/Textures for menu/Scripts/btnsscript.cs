using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class btnsscript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int target = 0;
    [SerializeField] private PlayerController PC;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch(target){
        case 1:
            PC.onLeftBtn=true;
            break;
        case 2:
            PC.onRightBtn=true;
            break;
        case 3:
            PC.onJumpBtn=true;
            break;
        }
        
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
         switch(target){
        case 1:
            PC.onLeftBtn=false;
            break;
        case 2:
            PC.onRightBtn=false;
            break;
        case 3:
            PC.onJumpBtn=false;
            break;
        }
        Debug.Log("OnPointerUp");
    }
}