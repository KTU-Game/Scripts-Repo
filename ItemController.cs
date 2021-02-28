using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    public GameObject examinationText;
    public Transform player;

    private void Update()
    {
        if (examinationText.activeSelf)
        {
            Vector3 _targetDirection = player.position - examinationText.transform.position;

            examinationText.transform.rotation = Quaternion.LookRotation(
                Vector3.RotateTowards(
                    examinationText.transform.forward, 
                    -_targetDirection, 
                    1, 
                    0
                    ));
        }
    }

    public void Activate(bool _activate)
    {
        examinationText.SetActive(_activate);
    }

}
