using Unity.Mathematics;
using UnityEngine;

public class BombPlanter : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;

    public void Plant()
    {
        Instantiate(_bombPrefab, transform.position, quaternion.identity);
    }
}