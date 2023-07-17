using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlickerEnding : MonoBehaviour
{
    TextMeshProUGUI _title;

    bool _inCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        _title = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inCoroutine)
            StartCoroutine(FlickerTitle());
    }
    IEnumerator FlickerTitle()
    {
        _inCoroutine = true;

        _title.enabled = !_title.enabled;

        yield return new WaitForSeconds(0.7f);

        _inCoroutine = false;
    }
}
