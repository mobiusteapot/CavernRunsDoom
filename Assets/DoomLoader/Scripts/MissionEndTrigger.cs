using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionEndTrigger : MonoBehaviour, PokeableLinedef
{
    public void Poke(GameObject caller)
    {
        Doom.NextMission();
        Debug.Log("Mission end triggered!");
    }

    public void Init(Linedef linedef)
    {
        transform.SetParent(linedef.Front.Sector.floorObject.transform);
        gameObject.name = "MissionEndTrigger";
    }
}
