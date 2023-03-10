using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LowerableController : MonoBehaviour
{
  [SerializeField]
  private List<Lowerable> lowerables;

  [SerializeField]
  private float staggerInterval;

  public void LowerAll()
  {
    LowerOrRaiseAll("Lower");
  }

  public void RaiseAll()
  {
    LowerOrRaiseAll("Raise");
  }

  private void LowerOrRaiseAll(string command)
  {
    bool shouldLower = command == "Lower";

    // Then its either a single gate or a left/right gate, so lower it all at once
    if (lowerables.Count <= 2)
    {
      lowerables.ForEach(delegate (Lowerable lowerable)
      {
        if (shouldLower)
        {
          lowerable.Lower();
        }
        else
        {
          lowerable.Raise();
        }
      });
    }

    // Otherwise find the middle element(s) and lower that first, then
    // stagger lower the others
    else
    {
      List<Lowerable> firstHalf;
      List<Lowerable> lastHalf;
      int middleIdx = lowerables.Count / 2;

      // If even, its harder
      if (lowerables.Count % 2 == 0)
      {
        Lowerable middle1 = lowerables[middleIdx - 1];
        Lowerable middle2 = lowerables[middleIdx];

        firstHalf = lowerables.GetRange(0, middleIdx - 1);
        lastHalf = lowerables.GetRange(middleIdx + 1, (lowerables.Count - 1) - middleIdx);

        if (shouldLower)
        {
          middle1.Lower();
          middle2.Lower();
        }
        else
        {
          middle1.Raise();
          middle2.Raise();
        }
      }
      // If odd, there is a centered middle piece!
      else
      {
        Lowerable middle = lowerables[middleIdx];

        firstHalf = lowerables.GetRange(0, middleIdx);
        lastHalf = lowerables.GetRange(middleIdx + 1, (lowerables.Count - 1) - middleIdx);

        if (shouldLower)
        {
          middle.Lower();
        }
        else
        {
          middle.Raise();
        }
      }

      firstHalf.Reverse();
      StartCoroutine(StaggerRoutine(firstHalf, lastHalf, shouldLower));
    }
  }

  private IEnumerator StaggerRoutine(List<Lowerable> first, List<Lowerable> second, bool shouldLower)
  {
    for (int i = 0; i < first.Count; i++)
    {
      yield return new WaitForSeconds(staggerInterval);
      Lowerable firstGate = first[i];
      Lowerable secondGate = second[i];

      if (shouldLower)
      {
        firstGate.Lower();
        secondGate.Lower();
      }
      else
      {
        firstGate.Raise();
        secondGate.Raise();
      }
    }
  }
}
