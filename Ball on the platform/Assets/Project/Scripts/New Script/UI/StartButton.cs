using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace NewScript 
{
    public class StartButton : MonoBehaviour
    {       
        [Inject] private GameManager _gameManager;

        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(_gameManager.StartGame);
        }
    }
}