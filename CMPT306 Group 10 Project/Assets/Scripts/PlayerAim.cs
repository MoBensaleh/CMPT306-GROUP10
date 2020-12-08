using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private FieldOfView fov;
    private float rotateZ;
    [SerializeField] private Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    public GameObject Player;
    Transform transform;

    private void Awake()
    {
        transform = Player.GetComponent<Transform>();
        spriteRenderer = Player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Aim();
        // Debug.Log(rotateZ);
    }

    private void Aim()
    {
        float fixedZ = -90f;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();

        rotateZ = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + 90);
        

        spriteRotation();
        fov.SetAimDirection(direction);

    }

    private void spriteRotation()
    {
        Debug.Log(rotateZ);

        Vector3 localScale = Vector3.one;
        // Front Facing Left
        if (rotateZ >= 170f && 180f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[0];
            //Debug.Log("Dir Changed 1");
        }
        // More-Left Facing
        else if (rotateZ >= -105f && -85f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[2];
            //Debug.Log("Dir Changed 2");
        }
        // Directly Left Facing
        else if (rotateZ >= -85f && -55f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[3];
            //Debug.Log("Dir Changed 3");
        }

        // Back Left 
        else if (rotateZ <= 5f && -5f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[4];
        }
        // Back
        else if (rotateZ <= 90f && 120f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[5];
            localScale.y = -1;
            transform.localScale = localScale;
            //Debug.Log("Dir Changed 4");
        }
        // Back Right
        else if (rotateZ <= 15f && 7f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[8];
            localScale.x = -1;
            transform.localScale = localScale;
        }
        // Directly Right
        else if (rotateZ <= 5f && -7f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[7];
        }
        // More Right Facing
        else if (rotateZ <= -165f && -150f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[1];
        }
    }
}
