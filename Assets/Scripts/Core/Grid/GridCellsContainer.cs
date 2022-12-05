using UnityEngine;

namespace Wuzzle.Core
{
    public class GridCellsContainer : MonoBehaviour
    {
        private GridCell[] gridCells;

        public GridCell[] GridCells => gridCells;

        private void Awake()
        {
            gridCells = new GridCell[25];

            int index = 0;
            foreach (Transform child in transform)
            {
                var cell = child.GetComponent<GridCell>();
                if (cell != null)
                {
                    gridCells[index] = cell;
                    index++;
                }
            }
        }

        [ContextMenu("Set Indexes for children cells")]
        public void SetIndexesForChildrenCells()
        {
            int index = 0;
            foreach (Transform child in transform)
            {
                var cell = child.GetComponent<GridCell>();
                if (cell != null)
                {
                    cell.SetIndex(index);
                    index++;
                }
            }
        }
    }
}

