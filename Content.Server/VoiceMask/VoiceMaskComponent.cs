<<<<<<< HEAD
using Content.Shared.Humanoid;
=======
using Content.Shared.Speech;
using Robust.Shared.Prototypes;
>>>>>>> upstream/master

namespace Content.Server.VoiceMask;

[RegisterComponent]
public sealed partial class VoiceMaskComponent : Component
{
    [DataField]
    [ViewVariables(VVAccess.ReadWrite)]
    public bool Enabled = true;

<<<<<<< HEAD
    [ViewVariables(VVAccess.ReadWrite)] public string VoiceName = "Unknown";
    [ViewVariables(VVAccess.ReadWrite)] public string VoiceId = SharedHumanoidAppearanceSystem.DefaultVoice; // Corvax-TTS
=======
    [DataField]
    [ViewVariables(VVAccess.ReadWrite)]
    public string VoiceName = "Unknown";

    /// <summary>
    /// If EnableSpeechVerbModification is true, overrides the speech verb used when this entity speaks.
    /// </summary>
    [DataField]
    [ViewVariables(VVAccess.ReadWrite)]
    public ProtoId<SpeechVerbPrototype>? SpeechVerb;
>>>>>>> upstream/master
}
