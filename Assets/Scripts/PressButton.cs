using UnityEngine;

public class PressButton : MonoBehaviour
{
  private bool pressed = false;

  [SerializeField]
  private Animator animator;

  private void Update()
  {
    if (Input.anyKeyDown)
    {
      pressed = !pressed;
      animator.SetBool("Pressed", pressed);
    }
  }

  [ContextMenu("Press Button")]
  public void ButtonPress()
  {
    animator.SetBool("Pressed", true);
  }

  [ContextMenu("Unpress Button")]
  public void ButtonUnpress()
  {
    animator.SetBool("Pressed", false);
  }
}

