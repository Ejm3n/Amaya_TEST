using UnityEngine;

namespace AmayaTest.Data
{
    [CreateAssetMenu(fileName = "new CardDataBundle", order = 10, menuName = "Card Data Bundle")]
    public class CardDataBundle: ScriptableObject
    {
        [SerializeField] 
        private CardData[] _cardData;
        
        public CardData[] CardData => _cardData;
    }
}
