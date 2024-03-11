using Content.Shared.Construction.Components;
using Content.Shared.ADT.ADTSubFloorCard;

namespace Content.Server.ADT.ADTSubFloorCard;

public sealed class ADTSubFloorHideCardSystem : SharedADTSubFloorHideCardSystem
{
    public override void Initialize()
    {
        base.Initialize();
        // SubscribeLocalEvent<ADTSubFloorHideCardComponent, AnchorAttemptEvent>(OnAnchorAttempt);
        // SubscribeLocalEvent<ADTSubFloorHideCardComponent, UnanchorAttemptEvent>(OnUnanchorAttempt);
    }

    // private void OnAnchorAttempt(EntityUid uid, ADTSubFloorHideCardComponent component, AnchorAttemptEvent args)
    // {
    //     // No teleporting entities through floor tiles when anchoring them.
    //     var xform = Transform(uid);

    //     if (MapManager.TryGetGrid(xform.GridUid, out var grid)
    //         && HasFloorCover(grid, grid.TileIndicesFor(xform.Coordinates)))
    //     {
    //         args.Cancel();
    //     }
    // }

    // private void OnUnanchorAttempt(EntityUid uid, ADTSubFloorHideCardComponent component, UnanchorAttemptEvent args)
    // {
    //     // No un-anchoring things under the floor. Only required for something like vents, which are still interactable
    //     // despite being partially under the floor.
    //     if (component.IsUnderCover)
    //         args.Cancel();
    // }
}
