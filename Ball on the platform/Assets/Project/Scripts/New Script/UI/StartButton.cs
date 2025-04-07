using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace NewScript 
{
    public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {       
        [Inject] private GameManager _gameManager;
        private Button _button;
        private Vector3 _originalScale; // ��������� �������� ������ ������
        private Tween _pulseTween; // ��� �������� ��������

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(_gameManager.StartGame);
            _originalScale = transform.localScale; // ���������� ��������� �������
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