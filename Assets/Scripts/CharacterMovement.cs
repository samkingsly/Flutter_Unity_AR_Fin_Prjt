using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Joystick joystick;
    bool check = true;
    public GameObject emoteList;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("IdleFloat");
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
        moveVertical();
        moveTopBottom();
    }

    void moveHorizontal()
    {
        transform.Translate(-1 * speed * joystick.Horizontal * Time.deltaTime, 0, 0); 
    }
    void moveVertical()
    {
        transform.Translate(0, 0, -1 * speed * joystick.Vertical * Time.deltaTime);
    }

    void moveTopBottom()
    {
        float screenCenterY = Screen.height / 2f;

        // Convert the screen space y-coordinate to world space
        Vector3 worldCenter = Camera.main.ScreenToWorldPoint(new Vector3(0, screenCenterY, 0));

        // Set the GameObject's position to the world center's y-coordinate
        transform.position = new Vector3(transform.position.x, worldCenter.y, transform.position.z);
    }

    public void onEmoteClick()
    {
        
        if(check) 
        {
            check = false;
            joystick.enabled = false;
            emoteList.SetActive(true);
        }
        else
        {
            check = true;
            joystick.enabled = true;
            GetComponent<Animator>().Play("IdleFloat");
            emoteList.SetActive(false);
        }

    }

    private void OnMouseEnter()
    {
        emoteList.SetActive(false);
    }
}
