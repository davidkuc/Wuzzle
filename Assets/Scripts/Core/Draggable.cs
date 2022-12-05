using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Wuzzle.Settings;
using Zenject;

namespace Wuzzle.Core
{
    public class Draggable : Debuggable, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private GameSettings gameSettings;
        private Chip chip;
        private ChipsContainer chipsContainer;
        private Camera camera;
        private Vector3 mousePositionOffset;

        private GridCell gridCellAtDragStart;
        private GridCell currentGridCell;
        private bool isBeingDragged;

        public bool IsBeingDragged => isBeingDragged;

        private void Awake()
        {
            chip = GetComponent<Chip>();
        }

        private void Start()
        {
            gridCellAtDragStart = chip.CurrentGridCell;
            currentGridCell = chip.CurrentGridCell;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (isBeingDragged)
                return;

            if (collision.gameObject.CompareTag(gameSettings.chipTag))
            {
                var chip2 = collision.gameObject.GetComponent<Chip>();
                if (chip2 != null && ChipsEqualInRank(chip, chip2))
                    chipsContainer.ConnectChips(chip, chip2);
                else
                    GoBackToPreviousGridCell();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(gameSettings.gridCellTag))
            {
                currentGridCell = collision.GetComponent<GridCell>();

                PrintDebugLog("Current Cell Changed!");
            }

            PrintDebugLog("TriggerEnter!");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            PrintDebugLog("TriggerExit!");
        }

        [Inject]
        public void Setup(GameSettings gameSettings, Camera camera, ChipsContainer chipsContainer)
        {
            this.gameSettings = gameSettings;
            this.camera = camera;
            this.chipsContainer = chipsContainer;
        }

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
            isBeingDragged = true;
            gridCellAtDragStart = chip.CurrentGridCell;
            chip.OnDragStart();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isBeingDragged = false;
            chip.OnDragEnd();
        }

        public void OnDrag(PointerEventData eventData)
        {
            PrintDebugLog("MouseDrag!");
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }

        private Vector3 GetMouseWorldPosition() => camera.ScreenToWorldPoint(Input.mousePosition);

        private bool ChipsEqualInRank(Chip chip1, Chip chip2) => chip1.ChipColorRank == chip2.ChipColorRank;

        private void GoBackToPreviousGridCell() => transform.position = gridCellAtDragStart.transform.position;
    }
}

