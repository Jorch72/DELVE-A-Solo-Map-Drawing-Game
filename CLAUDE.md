# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

DelveCS is a C# Windows Forms implementation of the **DELVE** tabletop solo map-drawing game. Players explore dungeons, gather resources, and fight monsters. The project supports multiple game expansions: World Layers, Bloodrunes, Feast and Famine, Honor, and Biomes.

## Build and Run

**Build the application:**
```powershell
dotnet build
```

**Run the application:**
```powershell
dotnet run
```

The application requires .NET 10.0 or later and the Windows Forms framework (net10.0-windows target).

## Project Structure

### Core Architecture

**Classes/** — Game logic and mechanics
- `Game.cs` — Main game state container; manages turns, resources, trade goods, and overall game flow
- `Map.cs` — 1D map representation of rooms in linear arrangement (direction-based room placement)
- `Explore.cs` — Handles exploration mechanics (deck drawing, resource/monster discovery)
- `Explorer.cs` — Player character state (position, attributes, current room)
- `Room.cs` — Base room class; `DelveRoom`, `RiseRoom`, `UmbraRoom` are expansion-specific implementations
- `Card.cs`, `Deck.cs` — Card drawing and deck management for exploration results
- `Monster.cs`, `NaturalFormation.cs`, `LegendaryFind.cs` — Combat and discovery encounters
- Expansion-specific: `WorldLayer.cs`, `BloodRunes.cs`, `Biomes.cs`, `Honor.cs`, `Remnant.cs`
- `Challenges.cs`, `Invention.cs`, `Magic.cs` — Optional game mechanics

**Forms/** — Windows Forms UI
- `frmStartUp.cs` — Initial startup form (game setup, expansion selection)
- `frmMain.cs` — Main game board UI; displays map, resources, turn overview, and movement/action buttons
- `frmBuild.cs` — Room construction/building interface
- `frmHire.cs` — Adventurer hiring interface
- `frmChallenges.cs` — Challenge selection and management

### Key Design Patterns

1. **Room Type Hierarchy** — Base `Room` class with expansion-specific subclasses (`DelveRoom`, `RiseRoom`, `UmbraRoom`) for different rule sets
2. **Card-Driven Exploration** — `Explore` class uses a `Deck` to draw cards; results (resources, trade goods, monsters) are generated via `ExploreResult`
3. **Position Tracking** — Linear map stored as `List<Room>`; `Direction` enum (Right/Left/Up/Down) controls room placement
4. **State Management** — `Game` object holds all mutable state and is passed to forms for updates
5. **Expansion Flags** — `frmMain` uses boolean flags (`useWorldLayers`, `useBloodrunes`, etc.) to enable/disable expansion rules

### Room Enumeration

Rooms are typed as enums within their room class (e.g., `DelveRoom.RoomType.Entrance`, `DelveRoom.RoomType.CrystalCavern`). The current implementation stores rooms in a single linear map; future expansion may separate by game mode or expansion.

## Development Notes

- **Nullable reference types enabled** (`<Nullable>enable</Nullable>`). Use `?` notation and null-coalescing to handle optional values.
- **Implicit usings enabled** — `using` statements for common namespaces are auto-generated.
- **No unit tests** — Currently a UI-driven application. Manual testing via the forms is the primary validation method.
- **String extension methods** — `ReplaceFirst()` and `ReplaceFirstAt()` in `ExtensionMethods.cs` are available for log string manipulation.

## Common Tasks

**Starting a new game:** The game loop begins in `frmStartUp`, which passes control to `frmMain` once expansions are selected. `Game` class initializes a `Map` with an Entrance room and an `Explore` deck.

**Adding a new room type:** Define it in the appropriate room class enum (e.g., `DelveRoom.RoomType`), then handle its mechanics in room-specific logic (e.g., special effects in `Explore.cs` or `Game.cs`).

**Handling exploration results:** Modify `Explore.DoExplore()` to generate new result types, and update `frmMain` event handlers to display/process them.

**Expansion integration:** Add a boolean flag in `frmMain`, pass it through to `Game`, and condition room/card/mechanic availability on the flag.
