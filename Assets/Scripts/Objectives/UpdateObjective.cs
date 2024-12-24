using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObjective : MonoBehaviour
{
    public GameController controller;

    public string objective;

    public void UpdatedObjective()
    {
        controller.UpdateObjective(objective);
    }
}
