using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerController.touchingGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerController.touchingGround = false;
        }
    }
}
