using Content.Shared.Interaction;
using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Map;
using Robust.Shared.Serialization;
using Robust.Shared.Timing;
using Robust.Shared.Utility;
using System.Linq;

namespace Content.Shared.ADT.ADTSubFloorCard;

public abstract class SharedADTTrayScannerCardSystem : EntitySystem
{
    [Dependency] private readonly SharedAppearanceSystem _appearance = default!;

    public const float SubfloorRevealAlpha = 0.8f;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ADTTrayScannerCardComponent, ComponentGetState>(OnTrayScannerGetState);
        SubscribeLocalEvent<ADTTrayScannerCardComponent, ComponentHandleState>(OnTrayScannerHandleState);
        SubscribeLocalEvent<ADTTrayScannerCardComponent, ActivateInWorldEvent>(OnTrayScannerActivate);
    }

    private void OnTrayScannerActivate(EntityUid uid, ADTTrayScannerCardComponent scanner, ActivateInWorldEvent args)
    {
        SetScannerEnabled(uid, !scanner.Enabled, scanner);
    }

    private void SetScannerEnabled(EntityUid uid, bool enabled, ADTTrayScannerCardComponent? scanner = null)
    {
        if (!Resolve(uid, ref scanner) || scanner.Enabled == enabled)
            return;

        scanner.Enabled = enabled;
        //Dirty(scanner);

        // We don't remove from _activeScanners on disabled, because the update function will handle that, as well as
        // managing the revealed subfloor entities

        if (TryComp<AppearanceComponent>(uid, out var appearance))
        {
            _appearance.SetData(uid, TrayScannerVisual.Visual, scanner.Enabled ? TrayScannerVisual.On : TrayScannerVisual.Off, appearance);
        }
    }

    private void OnTrayScannerGetState(EntityUid uid, ADTTrayScannerCardComponent scanner, ref ComponentGetState args)
    {
        args.State = new TrayScannerState(scanner.Enabled);
    }

    private void OnTrayScannerHandleState(EntityUid uid, ADTTrayScannerCardComponent scanner, ref ComponentHandleState args)
    {
        if (args.Current is not TrayScannerState state)
            return;

        SetScannerEnabled(uid, state.Enabled, scanner);
    }
}

[Serializable, NetSerializable]
public enum TrayScannerVisual : sbyte
{
    Visual,
    On,
    Off
}
