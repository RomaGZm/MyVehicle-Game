using UnityEngine;
using TMPro;
using DG.Tweening;

namespace VehicleGame.Gameplay.UI
{
    public class PopupText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textUI;

        private Tween currentTween;

        public void Play(string txt, Transform target, float speed, Vector2 direction,
                         Color color, int fontSize)
        {
            currentTween?.Kill();

            textUI.text = txt;
            textUI.color = color;
            textUI.fontSize = fontSize;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
            transform.position = screenPos;

            Vector3 endPos = screenPos + new Vector3(direction.x, direction.y) * speed;

            CanvasGroup cg = GetComponent<CanvasGroup>();
            cg.alpha = 1f;

            // Animation: move + fade
            currentTween = DOTween.Sequence()
                .Join(transform.DOMove(endPos, 1f).SetEase(Ease.OutQuad))
                .Join(cg.DOFade(0f, 1f))
                .OnComplete(() =>
                {
                    PopupTextManager.Instance.ReturnToPool(this);
                });
        }
    }
}
