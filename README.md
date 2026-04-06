![1.2.0-stable](https://img.shields.io/badge/AlkibitLLC.Collections-1.2.0--stable-green)

Some useful stuff, used in Alkibit packages and projects.

## Requirements
- AlkibitLLC.Input

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
### `Miscellaneous`

`enum Vector3Boolean`

An enum with 3 booleans

`enum Vector2Boolean`

An enum 2 booleans

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
- `Vector3 GetPosition()` - Gets the position of the target

`Vector3 GetTargetPosition(Target target)` or `Vector3 GetTargetPosition(TargetType type, Vector3 vector, Transform transform, string name)`

Gets the position of the target

---
### TimerData

A class, that is a timer

`float startTime`
`float time left`
`bool isLooping`
