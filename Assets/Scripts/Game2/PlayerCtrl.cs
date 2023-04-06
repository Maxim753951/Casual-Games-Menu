using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] float force;
    Vector3 Move = new Vector3(1, 0, 0);
    bool is_ground = false;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && is_ground)
        {
            rb.AddForce(Vector2.up * force);
        }
        if (Input.GetKey(KeyCode.A) && is_ground)
        {
            rb.velocity -= Move;
        }
        if (Input.GetKey(KeyCode.D) && is_ground)
        {
            rb.velocity += Move;
        }

        if (Input.GetKey(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "deck")
        {
            SceneManager.LoadScene("Game2");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            is_ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            is_ground = false;
        }
    }
}
