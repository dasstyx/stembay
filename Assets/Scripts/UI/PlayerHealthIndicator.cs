using stembay.Characters;
using TMPro;
using UnityEngine;

namespace stembay.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PlayerHealthIndicator : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _player;
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _text.text = _player.Hp.ToString();
        }
    }
}