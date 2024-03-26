using DG.Tweening;
using TMPro;
using UnityEngine;

namespace AmayaTest.UI
{
    public class GoalBar : MonoBehaviour
    {
        private const float FADE_DURATION = 3f;
        private const float FADE_ALPHA_END = 1f;
    
        [SerializeField] 
        private TextMeshProUGUI _text;

        public void SetGoal(string goalName)
        {
            _text.text = "Find " + goalName;
        }

        public void FadeFromOpaque()
        {
            _text.alpha = 0f;
            _text.DOFade(FADE_ALPHA_END, FADE_DURATION);
        }
    }
}
