using UnityEngine;

public class Lowerable : MonoBehaviour, ILowerable
{
  [SerializeField]
  private Animator animator;

  [SerializeField]
  private string animationParameter;

  [ContextMenu("Lower")]
  public void Lower()
  {
    animator.SetBool(animationParameter, true);
  }

  [ContextMenu("Raise")]
  public void Raise()
  {
    animator.SetBool(animationParameter, false);
  }
}

