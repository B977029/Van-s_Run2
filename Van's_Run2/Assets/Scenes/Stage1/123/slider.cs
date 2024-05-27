using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    public GameObject target;
    public GameObject goal;
    Slider slide;

    private float max;
    private float min;
    public float pos;
    // Start is called before the first frame update

    void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = 0;
        max = goal.transform.position.z;
        min = target.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (slide.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else transform.Find("Fill Area").gameObject.SetActive(true);
        pos = target.transform.position.z;

        slide.value = (pos-min)/ (max-min);
    }
}
