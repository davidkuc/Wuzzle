using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Draggable : Debuggable, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Camera camera;
    private Vector3 mousePositionOffset;

    private bool isOverGridCell;
    private GridCell currentGridCell;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOverGridCell = true;
        currentGridCell = collision.GetComponent<GridCell>();
        PrintDebugLog("TriggerEnter!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOverGridCell = false;
        PrintDebugLog("TriggerExit!");
    }

    [Inject]
    public void Setup(Camera camera) => this.camera = camera;

    public void OnPointerDown(PointerEventData eventData)
    {
        PrintDebugLog("MouseDown!");
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = currentGridCell.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {     
    }

    public void OnEndDrag(PointerEventData eventData)
    {    
    }

    public void OnDrag(PointerEventData eventData)
    {
        PrintDebugLog("MouseDrag!");
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private Vector3 GetMouseWorldPosition() => camera.ScreenToWorldPoint(Input.mousePosition);
}

