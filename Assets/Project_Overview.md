# 1. Project Overview

- **Project Type:** Virtual Reality Bowling Game built using the BNG Interaction Framework (VRIF)
- **Target Platforms:** Android (Meta Quest, likely standalone PCVR configuration also possible)
- **Core Features / Pillars:**
  - Immersive bowling gameplay experience using realistic physics and 6DOF VR interactions.
  - Hand and finger tracking powered by BNG HandPoser system.
  - Integrated UI system for menu navigation using VR controllers and hand interactions.
  - Physics-driven bowling alley and environment built with URP (Universal Render Pipeline).
  - Multiple scenes for testing locomotion, full-body avatars, hand posing, and physical object interaction.

# 2. Gameplay Flow / User Loop

- **Major States:**
  - **Boot / Main Menu:** Displays a welcome screen (Welcome_UI) with Play button.
  - **Level Selection:** The `Choose_Level_UI` interface lets players select beginner/intermediate/advanced lanes.
  - **Color Selection:** The `Choose_color_UI` allows choosing the color of the ball before play.
  - **Gameplay:** Player controls a VR Rig to grab and throw the bowling ball in the `bowling_club` environment.
  - **Score Display:** `Scoreboard_UI` updates player performance in real-time.
  - **Restart/Exit:** User can end session or restart round.

- **Core Loop:** Grab → Aim → Release Bowling Ball → Observe feedback (physics and score) → Repeat.
- **State Transitions:** Menu → Level select → Gameplay → Scoreboard → Restart or Exit.

# 3. Architecture (Runtime + Editor)

- **Runtime Systems:**
  - **XR Rig Advanced:** Manages player locomotion, inventory, and head/body tracking components.
  - **PlayerController + Locomotion:** BNG VR locomotion and input handling for XR controllers.
  - **ScoreManager:** Controls the scoring mechanics during gameplay.
  - **Interaction System:** Uses BNG Grabbable, SnapPoint, and Physics Hands for object manipulation.
  - **Global Volume:** Provides post-processing effects for the URP pipeline.

- **Editor Tooling:**
  - BNG Editor scripts for custom inspector controls (GrabbableEditor, ClimbableEditor, LeverEditor).
  - HandPoser editor extension for creating and editing VR hand poses.

- **Entry Points:** `Assets/Scenes/SampleScene.unity` serves as bootstrap (entry) scene.

- **Patterns & Communication:** Event-based interaction. Input System events propagate to locomotion and hand controllers via UnityEvents and `InputActionReference` objects. BNG heavily utilizes `ScriptableObject`-based HandPose definitions.

# 4. Scene Overview & Responsibilities

| Scene | Purpose |
|--------|----------|
| SampleScene | Main entry VR Bowling experience; player UI and environment setup. |
| Physics Hands / Quest Demo / XR Demo | Sandbox VR interaction demos built with BNG Framework. |
| Full Body Avatar | Demonstrates avatar rigging and IK system. |
| Vehicle Example / Vehicle Enter Exit | Showcases interactable vehicle mechanics. |
| HandPoser scenes | Used for designing grip poses and testing VR hand animation. |
| XRIT Examples | Integrations with XR Interaction Toolkit. |

- **Loading Strategy:** Single-scene active gameplay; additive loading is not required except for modular demos.
- **Responsibilities:**
  - XR Rig instantiation
  - EventSystem for UI
  - Environmental lighting and volumetric effects
  - Persistent ScoreManager across rounds.
- **Constraints:** Open only from main menu to ensure XR Rig initialization order (do not run isolated sub-demos without BNG setup).

# 5. UI System

- **Framework:** Unity UGUI.
- **Navigation:** Canvas-based UI with interactable buttons, toggles, and dropdowns for hand/controller input.
- **Binding Logic:** UI buttons trigger level load or configuration changes. Uses `EventSystem` + `XR Rig` ray interaction.
- **UI Style:**
  - Flat panels in world space.
  - Bold typography (Montserrat-Light).
  - Bright color-coded buttons (Blue/Red for selection).
  - Minimalistic and VR-accessible scaling.
  - Motion feedback through controller haptics.

# 6. Asset & Data Model

- **Asset Style:** Hybrid realistic–cartoonish 3D; combines detailed meshes for weapons, vehicles, and bowling alley props. Materials use PBR and ToonColor variants.
- **Data Formats:** `ScriptableObject` HandPoses, FBX mesh assets, .mat materials, prefabs for items.
- **Asset Organization:**
  - `BNG Framework/Models/Hands` – VR hand models for Oculus devices.
  - `Assets/Scenes/` – Entry-level scenes.
  - `BNG Framework/Prefabs` – Core VR prefabs.
- **Naming Rules:** Prefabs and materials follow semantic grouping (e.g., `PistolNEW`, `XR Rig Advanced`).

# 7. Project Structure (Repo & Folder Taxonomy)

- **Folder Layout:**
  - `/Assets/BNG Framework/` – Core framework (inputs, models, materials, editor, integrations).
  - `/Assets/Scenes/` – Project entry scene(s).
  - `/Assets/Sci-Fi UI/` – Auxiliary UI demo.
  - `/Assets/TextMesh Pro/Examples & Extras/` – Reference TMP scenes.
- **Content Locations:** Art → Models and Materials; Scripts → Framework/Scripts; UI → Canvas prefabs within SampleScene.

# 8. Technical Dependencies

- **Unity Version:** 6000.3.3f1
- **Render Pipeline:** URP 17.3 (Universal Render Pipeline variant).
- **XR SDKs:** OpenXR (1.16.1), Oculus (4.5.2), XR Management (4.5.4)
- **Packages:** Input System (1.17.0), TextMeshPro, Visual Scripting, Universal RP, ShaderGraph.
- **External Tools:** BNG Framework integrations with Oculus and XR Interaction Toolkit.

# 9. Build & Deployment

- **Build Steps:**
  1. Switch target platform to Android.
  2. Ensure XR Management subsystem is set to Oculus/OpenXR.
  3. Open `SampleScene`.
  4. Configure Quality Settings for Quest profile.
  5. Use `Build Settings > Build and Run` to deploy.
- **Supported Platforms:** Android VR (Meta Quest), optionally PCVR.
- **CI/CD:** Manual builds preferred; optional integration with Unity Cloud Build.
- **Environment Requirements:** Android SDK, Oculus Integration, URP profiles.

# 10. Style, Quality & Testing

- **Code Style:** follows BNG C# conventions (PascalCase for methods/classes, serialized fields exposed via [SerializeField]).
- **Performance Guidelines:**
  - Limit draw calls; merge static geometry.
  - Disable shadows for small mobile props.
  - Use baked lighting.
- **Testing Strategy:**
  - Manual playmode testing on headset.
  - Scripts validated with Unity Test Framework (1.6.0).
  - Demo scenes used for physical interaction regression testing.
- **Validation:** URP asset consistency (Global Volume references, XR camera stack integrity).

# 11. Notes, Caveats & Gotchas

- **Known Issues:**
  - HandPoser scenes occasionally lose reference to XR Rig when opened standalone.
  - Some prefabs (notably TableHandle, VirtualTabletop) have missing GUIDs; reimport may be required.
- **Dependency Rules:**
  - Editing InputAction assets requires updating XRInteractionManager prefabs.
  - Modifying HandPose assets may need rebake into HandPoseDefinition.
- **Deprecated Systems:**
  - Legacy input references remain for backward compatibility.
- **Platform Caveats:**
  - Quest builds need Android-specific shader stripping and lightmap compression.
  - Use mobile URP shaders for optimal performance.