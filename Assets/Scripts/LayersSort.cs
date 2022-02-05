using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LayersSort : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private bool _updatable;
    private Renderer _renderer;
    private int _sortingOrderBase;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _sortingOrderBase = _renderer.sortingOrder;

        Sort();
    }

    private void Update()
    {
        if (_updatable)
        {
            Sort();
        }
    }

    private void Sort()
    {
        var sortingOrder = _sortingOrderBase - (int) (transform.position.y + offset);
        _renderer.sortingOrder = sortingOrder;
    }
}