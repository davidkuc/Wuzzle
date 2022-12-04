using UnityEngine;
using Zenject;


public class Draggable : Debuggable
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
        isOverGridCell= false;
        PrintDebugLog("TriggerExit!");
    }

    [Inject]
    public void Setup(Camera camera) => this.camera = camera;

    private void OnMouseDown()
    {
        PrintDebugLog("MouseDown!");
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        PrintDebugLog("MouseDrag!");
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        transform.position = currentGridCell.transform.position;
    }

    private Vector3 GetMouseWorldPosition() => camera.ScreenToWorldPoint(Input.mousePosition);
}

