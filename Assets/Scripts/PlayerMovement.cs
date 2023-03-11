using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Vector2 input;
  private bool isFacingEast = false;
  private bool isFacingNorth = false;

  [SerializeField]
  private float velocity;

  [SerializeField]
  private Sprite slimeN, slimeNE, slimeE, slimeSE, slimeS;

  [SerializeField]
  private SpriteRenderer spriteRenderer;

  private void Update()
  {
    input.x = Input.GetAxisRaw("Horizontal");
    input.y = Input.GetAxisRaw("Vertical");

    transform.position += new Vector3(input.x, input.y, 0).normalized * velocity * Time.deltaTime;
    ChangeSprite();
  }

  private void ChangeSprite()
  {
    if (PressingN())
    {
      if (PressingE())
      {
        spriteRenderer.flipX = false;
        spriteRenderer.sprite = slimeNE;
      }
      else if (PressingW())
      {
        spriteRenderer.flipX = true;
        spriteRenderer.sprite = slimeNE;
      }
      else
      {
        spriteRenderer.sprite = slimeN;
      }
    }
    else if (PressingS())
    {
      if (PressingE())
      {
        spriteRenderer.flipX = false;
        spriteRenderer.sprite = slimeSE;
      }
      else if (PressingW())
      {
        spriteRenderer.flipX = true;
        spriteRenderer.sprite = slimeSE;
      }
      else
      {
        spriteRenderer.sprite = slimeS;
      }
    }
    else if (PressingE())
    {
      spriteRenderer.flipX = false;

      if (PressingN())
      {
        spriteRenderer.sprite = slimeNE;
      }
      else if (PressingS())
      {
        spriteRenderer.sprite = slimeSE;
      }
      else
      {
        spriteRenderer.sprite = slimeE;
      }
    }
    else if (PressingW())
    {
      spriteRenderer.flipX = true;

      if (PressingN())
      {
        spriteRenderer.sprite = slimeNE;
      }
      else if (PressingS())
      {
        spriteRenderer.sprite = slimeSE;
      }
      else
      {
        spriteRenderer.sprite = slimeE;
      }
    }
  }

  private bool PressingN()
  {
    return input.y == 1;
  }

  private bool PressingS()
  {
    return input.y == -1;
  }

  private bool PressingE()
  {
    return input.x == 1;
  }

  private bool PressingW()
  {
    return input.x == -1;
  }
}
