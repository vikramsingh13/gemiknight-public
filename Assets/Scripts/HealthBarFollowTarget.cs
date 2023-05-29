using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFollowTarget : MonoBehaviour
{
    public GameObject target;//target to follow
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(target != null)
        {
            rectTransform.anchoredPosition = target.transform.position;
        }
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
