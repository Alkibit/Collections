![version](https://img.shields.io/badge/Alkibit.Collections-1.0.0--stable-green)

Some useful unity stuff used in Alkibit packages and projects.

## Requirements
- The demo requires `Unity.TextMeshPro`, but if you don't use the demo, you don't need it

## Features

- [`Curves`](#curves)
- [`IOnUpdate`](#ionupdate)
- [`QuickBoundaries`](#quickboundaries)
- [`RandomizedArrayExtender`](#randomizedarrayextender)
- [`TargetSearch`](#targetsearch)
- [`TimeFormatting`](#timeformatting)
- [`TimerData`](#timerdata)
- [`ClassTween`](#classtween)
- [`UpdateManager`](#updatemanager)

### `Curves`

`CurvePoint`

A data variable that is used to generate `AnimationCurve` in `Curve` class:

- `float time` - The time of the point
- `float value` - The value of the point

`Curve`

A curve with a capability of an `AnimationCurve`:

- `AnimationCurve curve` - The animation curve
- `CurvePoint[] points` - The points of the curve
- `void SetCurve()` - Sets `curve` based on `points`

---
### `IOnUpdate`
Updates every frame by `UpdateManager` when is unpaused

`void OnUpdate()`

The function that is called every frame by `UpdateManager` when is unpaused

---
### `QuickBoundaries`

A static class to calculate boundaries

`BoxBoundary`

A box boundary with a volume:
- `Vector3 size` - the size of the box

`SphereBoundary`

A sphere boundary with a volume
- `float radius` - the radius of the sphere

`Boundary`

A generic boundary
- `enum BoundaryType` - `None`, `Box` or `Sphere`
- `BoxBoundary box` - the box
- `SphereBoundary sphere` - the sphere

`bool IsInsideBoundary(Vector3 position, Vector3 point, Boundary boundary)`

Gets if a point is in a boundary that is at the `position`

`void DrawGizmos`

Draws Gizmos of the boundary

---
### `RandomizedArrayExtender`
A useful utilite to get a random item from an array or a list

`.GetRandomItem()`

Returns a random item from an array or a list

---
### `TargetSearch`

A static class to search targets

`enum TargetType`

The type of the target to search:
- Vector
- Transform
- NamedObject
- Mouse

`Target`

The target to search:
- `TargetType type` - The type of the target
- `Vector3 vector3` - The vector
- `Transform transform` - The transform
- `string name` - The name of the object to search
- `Vector3 position {get;}` - The position of the target

`Vector3 GetTargetPosition(Target target)` or `Vector3 GetTargetPosition(TargetType type, Vector3 vector, Transform transform, string name)`

Gets the position of the target

---
### `TimeFormatting`

Formats time into a string dinamically

`string FormatTime(float time, bool showMilliseconds = false)`

Formats the time into a string, the inputs are self-explanatory

---
### TimerData

A class, that is a timer

`float startTime`
`float time left`
`bool isLooping`

---
### ClassTween

A class to tween values for smooth animations using code

`enum Tween`

**This is outside of this class, but in the same namespace.** The type of the tween:
- `Linear` - the speed is the same during the whole tween
- `Logarithmic` - the speed is high at the beggining, but low at the end
- `Exponential` - the speed is low at the beggining, but high at the end

`Vector3 TweenVector(Vector3 start, Vector3 target, float speed, Tween tween)`
Tweens a vector from the start to the target with the speed and tween type

`float TweenFloat(float start, float target, float speed, Tween tween)`
Tweens a float from the start to the target with the speed and tween type

---
### UpdateManager
This class updates every `IOnUpdate` and simulates 2d physics using scripted updates.

`IsPaused`

The state of the game, and is readonly

`UpdateManager Instance`

The current instance of the `UpdateManager`

`bool isPaused`

The inspector variable to show the state of the game, but changes it is `controlPause` is set to true.

`bool control pause`

Allows to control the state of the game using `isPaused variable`

`void Pause()`

Pauses the game

`void Resume()`

Resumes the game

`void TogglePause`

Toggles the pause state of the game