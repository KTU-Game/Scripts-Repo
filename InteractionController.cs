using UnityEngine;
using TMPro;
using System.Collections;

public class InteractionController : MonoBehaviour
{
    public TMP_Text DisplayText;
    public float MaxInteractionDistance = 2f;
    public float DisplayTextTime = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnExamine();
        }
    }

    private void OnExamine()
    {
        int mask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(
            transform.position,
            transform.forward,
            out var hit,
            MaxInteractionDistance,
            mask
        ))
        {
            StartCoroutine(HandleInteraction(hit));
        }
    }

    IEnumerator HandleInteraction(RaycastHit hit)
    {
        DisplayText.text = hit.transform.gameObject.name;

        yield return new WaitForSeconds(DisplayTextTime);

        DisplayText.text = "";
    }
}
