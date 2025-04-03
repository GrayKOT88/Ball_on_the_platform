using UnityEngine;

namespace NewScript 
{
    public class TimerController : MonoBehaviour
    {
        private TimerModel _model;
        private TimerView _view;

        private void Awake()
        {
            _model = new TimerModel();
            _view = GetComponent<TimerView>();
            
            _model.OnTimeUpdated += HandleTimeUpdated;

            // Инициализация
            _view.UpdateBestTimeDisplay(_model.LoadBestTime());
        }

        private void Update()
        {
            _model.UpdateTime(Time.deltaTime);
        }

        public void StartTimer()
        {
            _model.StartTimer();
        }

        public void StopTimer()
        {
            _model.StopTimer();
            _model.SaveBestTime();
        }

        private void HandleTimeUpdated()
        {
            _view.UpdateTimerDisplay(_model.CurrentTime);
        }

        private void OnDestroy()
        {
            _model.OnTimeUpdated -= HandleTimeUpdated;
        }
    }
}