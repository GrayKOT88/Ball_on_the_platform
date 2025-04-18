using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NewScript 
{
    public abstract class AnimatedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected Button _button;
        private Vector3 _originalScale;
        private Tween _pulseTween;

        protected abstract void OnButtonClick();

        protected virtual void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
            _originalScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _pulseTween?.Kill();
            _pulseTween = transform.DOPunchScale(_originalScale * 0.1f, 0.5f, 1, 0.5f)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.InOutQuad);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _pulseTween?.Kill();
            transform.localScale = _originalScale;
        }

        private void OnDestroy()
        {
            _pulseTween?.Kill();
        }
    }
}