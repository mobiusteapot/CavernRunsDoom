using UnityEngine;

public class Door1LinedefController : MonoBehaviour, PokeableLinedef
{
    public Door1SectorController sectorController;

    public void Poke(GameObject caller)
    {
        if (sectorController.CurrentState != Door1SectorController.State.Open &&
            sectorController.CurrentState != Door1SectorController.State.Opening)
        {
            sectorController.CurrentState = Door1SectorController.State.Opening;
            sectorController.waitTime = 4;
        }
    }

    public void Init(Linedef linedef)
    {
        if (linedef.Back == null)
            return;

        sectorController = linedef.Back.Sector.ceilingObject.GetComponent<Door1SectorController>();
        if (sectorController == null)
        {
            sectorController = linedef.Back.Sector.ceilingObject.AddComponent<Door1SectorController>();
            sectorController.originalHeight = linedef.Back.Sector.ceilingHeight;
            sectorController.currentHeight = sectorController.originalHeight;
            sectorController.targetHeight = linedef.Front.Sector.ceilingHeight - MapLoader._4units;
        }
        else
        {
            if (sectorController.targetHeight > linedef.Front.Sector.ceilingHeight - MapLoader._4units)
                sectorController.targetHeight = linedef.Front.Sector.ceilingHeight - MapLoader._4units;
        }

        transform.SetParent(linedef.Back.Sector.ceilingObject.transform);
    }
}

