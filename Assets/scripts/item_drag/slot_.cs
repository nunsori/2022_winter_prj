using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slot_ : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        item_drag.enter_slot = gameObject;
        //Debug.Log(item_drag.enter_slot);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        item_drag.enter_slot = null;
        //Debug.Log(item_drag.enter_slot);
    }

    public void OnDrop(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
