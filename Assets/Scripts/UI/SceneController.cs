using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaTest.UI
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] 
        private Image _endGamePanel;
        
        [SerializeField]
        private Button _restartButton;

        public void TurnOn()
        {
            _restartButton.gameObject.SetActive(true);
            _endGamePanel.DOFade(0.9f, 3f);
        }
    
        public void TurnOff()
        {
            _restartButton.gameObject.SetActive(false);
            _endGamePanel.DOFade(0f, 3f);
        }
    }
}
