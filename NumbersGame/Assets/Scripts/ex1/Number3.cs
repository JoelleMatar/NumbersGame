using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number3 : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace;
    private Vector2 initialPos;
    private float deltaX, deltaY;
    public static bool locked;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(5, 5);
        initialPos = transform.position;
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(5, 5);
        if (Input.touchCount > 0 && !locked && Manager.nb3)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        Manager.nb5 = false;
                        Manager.nb7 = false;
                        Manager.nb10 = false;
                    }
                    break;

                case TouchPhase.Moved:
                    Physics.IgnoreLayerCollision(5, 5);
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(objectPlace.position.x, objectPlace.position.y);
                        locked = true;
                        Manager.nb5 = true;
                        Manager.nb7 = true;
                        Manager.nb10 = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                        Manager.nb5 = true;
                        Manager.nb7 = true;
                        Manager.nb10 = true;
                    }
                    break;
            }
        }
    }
}
