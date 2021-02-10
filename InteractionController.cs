using UnityEngine;
using TMPro;

public class InteractionController : MonoBehaviour
{
    public TMP_Text DisplayText;
    public float MaxInteractionDistance = 2f;
    public float DisplayTextTime = 2f;

    private float _timer;
    private bool _isShowing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnExamine();
        }

        TimerManagement();
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
            HandleInteraction(hit);
        }
    }

    private void HandleInteraction(RaycastHit hit)
    {
        DisplayText.text = hit.transform.gameObject.name;
        _timer = 0;
        _isShowing = true;
    }

    private void TimerManagement()
    {
        if (_isShowing)
        {
            _timer += Time.deltaTime;
            if (_timer >= DisplayTextTime)
            {
                _isShowing = false;
            }
        }
        else
        {
            DisplayText.text = "";
        }
    }
}
