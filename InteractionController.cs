using UnityEngine;
using TMPro;
using System.Collections;

public class InteractionController : MonoBehaviour
{
    public float MaxInteractionDistance = 2f;
    public float DisplayTextTime = 2f;
    public Inventory inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnExamine();
        }
    }

    private void OnExamine()
    {
        if (Physics.Raycast(
            transform.position,
            transform.forward,
            out var hit,
            MaxInteractionDistance
        ))
        {
            var _examinable = hit.collider.GetComponentInParent<ItemController>();
            if (_examinable != null)
            {
                if (_examinable.item.pickable)
                {
                    inventory.AddItem(_examinable.item);
                    Destroy(_examinable.gameObject);
                }
                else if (_examinable.item.examinable)
                    StartCoroutine(HandleExamination(_examinable));
            }
                
        }
    }

    IEnumerator HandleExamination(ItemController _examinable)
    {
        _examinable.Activate(true);
        yield return new WaitForSeconds(DisplayTextTime);
        _examinable.Activate(false);
    }
}
