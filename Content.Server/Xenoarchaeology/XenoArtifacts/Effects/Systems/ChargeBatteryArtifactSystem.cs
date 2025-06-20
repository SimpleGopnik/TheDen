// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 sleepyyapril <123355664+sleepyyapril@users.noreply.github.com>
//
// SPDX-License-Identifier: MIT

using Content.Server.Power.Components;
using Content.Server.Power.EntitySystems;
using Content.Server.Xenoarchaeology.XenoArtifacts.Effects.Components;
using Content.Server.Xenoarchaeology.XenoArtifacts.Events;
using Robust.Server.GameObjects;

namespace Content.Server.Xenoarchaeology.XenoArtifacts.Effects.Systems;

/// <summary>
/// This handles <see cref="ChargeBatteryArtifactComponent"/>
/// </summary>
public sealed class ChargeBatteryArtifactSystem : EntitySystem
{
    [Dependency] private readonly BatterySystem _battery = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly TransformSystem _transform = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        SubscribeLocalEvent<ChargeBatteryArtifactComponent, ArtifactActivatedEvent>(OnActivated);
    }

    private void OnActivated(EntityUid uid, ChargeBatteryArtifactComponent component, ArtifactActivatedEvent args)
    {
        foreach (var battery in _lookup.GetEntitiesInRange<BatteryComponent>(_transform.GetMapCoordinates(uid), component.Radius))
        {
            _battery.SetCharge(battery, battery.Comp.MaxCharge, battery);
        }
    }
}
