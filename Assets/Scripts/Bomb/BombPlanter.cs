using Unity.Mathematics;
using UnityEngine;

namespace stembay.Bomb
{
    public class BombPlanter : MonoBehaviour
    {
        [SerializeField] private GameObject _bombPrefab;

        public void Plant()
        {
            Instantiate(_bombPrefab, transform.position, quaternion.identity);
        }
    }
}