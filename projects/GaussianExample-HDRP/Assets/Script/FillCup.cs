using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCup : MonoBehaviour
{
    public GameObject coffee;
    public float timeElapsed;
    public float lerpDuration = 3;

    public float startValue;
    public float endValue;
    public float valueToLerp;
    public bool makeCoffee = false;

    public bool touched = false;

    // Start is called before the first frame update
    void Start()
    {
        coffee.SetActive(false);
        makeCoffee = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (makeCoffee)
        {
            if (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
            coffee.transform.position = new Vector3(coffee.transform.position.x, valueToLerp, coffee.transform.position.z);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(!touched)
        {
            touched = true;
            Debug.Log("toucheddddddd");
            coffee.SetActive(true);
            startValue = coffee.transform.position.y;
            endValue = startValue + 0.02f;
            makeCoffee = true;
        }
    }
}
