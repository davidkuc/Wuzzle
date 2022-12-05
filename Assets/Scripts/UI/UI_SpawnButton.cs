using UnityEngine;
using Wuzzle.Core;
using Zenject;

namespace Wuzzle.UI.Buttons
{
    public class UI_SpawnButton : MonoBehaviour
    {
        private ChipsContainer chipsContainer;

        public void SpawnChips() => chipsContainer.RespawnChips();

        [Inject]
        public void Setup(ChipsContainer chipsContainer) => this.chipsContainer = chipsContainer;
    }
}

