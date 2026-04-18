![version](https://img.shields.io/badge/Alkibit.Collections-1.0.1--stable-green)

## About
This is a unity package, that is used by Alkibit's other packages and games.

### Table of contents
- [Requirements](#requirements)
- [Features](#features)
    - [`Curves`](#curves)
    - [`IOnUpdate`](#ionupdate)
    - [`QuickBoundaries`](#quickboundaries)
    - [`RandomizedArrayExtender`](#randomizedarrayextender)
    - [`TargetSearch`](#targetsearch)
    - [`TimeFormatting`](#timeformatting)
    - [`TimerData`](#timerdata)
    - [`ClassTween`](#classtween)
    - [`UpdateManager`](#updatemanager)
- [Samples](#samples)
    - [`DespawnableObject`](#despawnableobject)
    - [`ObjectSpawner`](#objectspawner)
    - [`RotateTowards`](#rotatetowards)
    - [`TargetFollowing`](#targetfollowing)
    - [`Timer`](#timer)

## Requirements
- The samples require `Unity.TextMeshPro`

## Features
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

The time that you have at the start of the timer
`float time left`

The time you have left, mainly used as a display
`bool isLooping`

Does a timer restart when it finishes? It doesn't appear in inspector

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

---

## Samples

### `DespawnableObject`

Destroys an object after some time

`TimerData timer`

The timer to be destroyed

---
### ObjectSpawner

Spawns objects using Curves and a parent GameObject

`SpawningData`

The spawn pool for one prefab
- `GameObject prefab` - that is the prefab
- `int times` - how much should it appear

`SpawningData[] data`

The data about spawning

`Transform points`

The parent GameObject that has the points as its children

`Curve curve`

The curve of the time between the rounds

`public int round`

Round count

---
### `RotateTowards`

Rotates towards a target

`Target target`

The target to rotate towards

`float offset`

The offset of turning

---
### TargetFollowing

This script makes an object follow `Target` using a `Tween`. 
It has theese variations:
- `TargetFollowing2D` - Does not move Z axis
- `PhysicsTargetFollowing` - Uses `Rigidbody` component to be moved around
- `PhysicsTargetFollowing2D` - Uses `Rigidbody2D` component to be moved around and doesn't move Z axis
- `GridTargetFollowing2D` - Is snapped to grid and doesn't move automatically unless `Move()` is called. It doesn't has `tween` and `offset`, but has `frequency`, that defines how frequently will it move on `Move()`

Every variation has theese fields:

`Target target`

The target to follow

`Tween tween`

The tween to use

`float speed`

The speed of movement

`Vector3 offset`/`Vector2 offset`

The offset of the move

---
### `Timer`

A basic `MonoBehaviour` implementation of `TimerData` with an ability to display time onto `TextMeshProUGUI`

`TextMeshProUGUI text`

The text component to cast the time to

`bool showMilliseconds`

To show milliseconds or not

`TimerData timer`

The timer

`UnityEvent onTimerEnd`

Is being called when timer reaches zero