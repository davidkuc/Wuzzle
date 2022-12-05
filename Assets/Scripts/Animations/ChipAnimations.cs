using UnityEngine;

namespace Wuzzle.Animations
{
    public class ChipAnimations : Debuggable
    {
        [Header("Animations")]
        [SerializeField] private float spawnAnimTime;
        [SerializeField] private Vector2 targetScale;
        private Vector2 defaultScale;
        [Space(2)]
        [SerializeField] private float dragAnimTime;
        [Space(2)]
        [SerializeField] private float connectEnterAnimTime;
        [SerializeField] private float connectExitAnimTime;

        private void Awake()
        {
            defaultScale = transform.localScale;
        }

        [ContextMenu("Spawn Animation")]
        public void SpawnAnimation() => LeanTween.scale(gameObject, targetScale, spawnAnimTime).setEaseInCubic().setLoopPingPong(1);

        [ContextMenu("Connect Animation")]
        public void ConnectAnimation()
        {
            LeanTween.scale(gameObject, targetScale, connectEnterAnimTime / 2)
                .setEaseOutQuart().setOnComplete(() => LeanTween.scale(gameObject, defaultScale, connectExitAnimTime).setEaseOutQuart());
        }

        [ContextMenu("Drag Start Animation")]
        public void DragStartAnimation() => LeanTween.scale(gameObject, targetScale, dragAnimTime);

        [ContextMenu("Drag End Animation")]
        public void DragEndAnimation() => LeanTween.scale(gameObject, defaultScale, dragAnimTime);
    }
}

