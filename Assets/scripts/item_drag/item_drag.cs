using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//작동되게 하려면 main camera에  Physics 2D Raycaster 혹은 3d일경우 Physics Raycaster 추가해서 하면 작동함


public class item_drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public GameObject drag_parent;
    public GameObject origin_parent;

    public static GameObject enter_slot;

    private Vector3 temp_vec3 = Vector3.zero;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        origin_parent = rectTransform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

        rectTransform.SetParent(drag_parent.GetComponent<RectTransform>());

        temp_vec3.x = Input.mousePosition.x;
        temp_vec3.y = Input.mousePosition.y;

        rectTransform.transform.position = temp_vec3;

        drag_parent.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        temp_vec3.x = Input.mousePosition.x;
        temp_vec3.y = Input.mousePosition.y;

        rectTransform.position = temp_vec3;

        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if(enter_slot == null)
        {
            rectTransform.SetParent(origin_parent.GetComponent<RectTransform>());
            rectTransform.localPosition = Vector3.zero;
        }
        else
        {
            rectTransform.SetParent(enter_slot.GetComponent<RectTransform>());
            rectTransform.localPosition = Vector3.zero;
            origin_parent = rectTransform.parent.gameObject;
        }

        drag_parent.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //throw new System.NotImplementedException();
    }
}
