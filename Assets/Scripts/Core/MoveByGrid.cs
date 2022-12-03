using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class MoveByGrid : MonoBehaviour
  {
    [SerializeField] private Grid grid;
    [SerializeField] private Vector2 movePos;
    Camera camera;

    private void Awake()
    {
        camera = Camera.main;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
           movePos = camera.ScreenToWorldPoint(mousePos);
            MoveTo();
        }
    }

    [ContextMenu("move")]
    public void MoveTo()
    {
        var _targetCell = grid.WorldToCell(movePos);

        var pos = grid.GetCellCenterWorld(_targetCell);
        // Snap the player to the center of the initial cell
        transform.position = grid.CellToWorld(_targetCell);
        //transform.position = pos;
    }
}

