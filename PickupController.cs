using UnityEngine;
using TMPro;

public class PickupController : MonoBehaviour
{
    public TMP_Text PointsText;

    private int _objectsPicked = 0;
    private int _pickupLayer;

    private void Awake()
    {
        _pickupLayer = LayerMask.NameToLayer("Interactable");
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.layer == _pickupLayer)
        {
            UpdateUI(++_objectsPicked);
            Destroy(obj);
        }
    }

    private void UpdateUI(int points)
    {
        PointsText.text = $"Points: {points}";
    }
}
