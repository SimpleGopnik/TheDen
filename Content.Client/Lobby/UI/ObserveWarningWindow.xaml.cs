// SPDX-FileCopyrightText: 2021 moonheart08 <moonheart08@users.noreply.github.com>
// SPDX-FileCopyrightText: 2022 Paul Ritter <ritter.paul1@googlemail.com>
// SPDX-FileCopyrightText: 2022 wrexbe <81056464+wrexbe@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 DEATHB4DEFEAT <77995199+DEATHB4DEFEAT@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 sleepyyapril <123355664+sleepyyapril@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later AND MIT

using JetBrains.Annotations;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Lobby.UI;

[GenerateTypedNameReferences]
[UsedImplicitly]
public sealed partial class ObserveWarningWindow : DefaultWindow
{
    public ObserveWarningWindow()
    {
        Title = Loc.GetString("observe-warning-window-title");
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

        ObserveButton.OnPressed += _ => { Close(); };
        NevermindButton.OnPressed += _ => { Close(); };
    }
}
