ArgSentry
=======================

![Nuget](https://img.shields.io/nuget/v/argsentry)
![Nuget](https://img.shields.io/nuget/dt/argsentry)

> **⚠️ Archived — no longer maintained.** Most of what `Prevent` does is now built into
> .NET itself (`ArgumentNullException.ThrowIfNull`, `ArgumentException.ThrowIfNullOrEmpty`,
> `ArgumentOutOfRangeException.ThrowIfGreaterThan`, etc., .NET 6/8+). For the rest
> (collection/Guid/default-value checks), see [Ardalis.GuardClauses](https://github.com/ardalis/GuardClauses),
> which is actively maintained. This package will remain on NuGet as-is for existing
> consumers, but there will be no further updates, bug fixes, or releases.

ArgSentry is a .NET / .NET Core utility library for validating method argument values.


```c#
/// <summary>
/// Does something useless...but safely.
/// </summary>
/// <param name="nonNullObj">A required, non-null object.</param>
/// <param name="positiveNumber">A positive number.</param>
/// <param name="requiredString">A required, non-null, non-empty, non-white space string.</param>
/// <param name="nonEmptyList">A required non-null, non-empty collection.</param>
/// <param name="nonEmptyGuid">A non-empty GUID.</param>
/// <returns></returns>
public bool DoSomething(
    object nonNullObj, 
    int positiveNumber, 
    string requiredString, 
    List<string> nonEmptyList, 
    Guid nonEmptyGuid)
{
    Prevent.NullObject(nonNullObj, nameof(nonNullObj));
    Prevent.ValueLessThanOrEqualTo(positiveNumber, 0, nameof(positiveNumber));
    Prevent.NullOrWhiteSpaceString(requiredString, nameof(requiredString));
    Prevent.NullOrEmptyCollection(nonEmptyList, nameof(nonEmptyList));
    Prevent.EmptyGuid(nonEmptyGuid, nameof(nonEmptyGuid));

    return true;
}
```