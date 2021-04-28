using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject checkedObject;
    public static int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        checkedObject.SetActive(false);
        obj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(5, 5);
        if (Input.touchCount > 0 && count < 4)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && !checkedObject.activeSelf)
                {
                    checkedObject.SetActive(true);
                    obj.SetActive(false);
                    count++;
                }
        }
    }

    void OnMouseDown()
    {
        if (count < 4 && !checkedObject.activeSelf)
        {
            checkedObject.SetActive(true);
            obj.SetActive(false);
            count++;
        }
    }
}
