ArgSentry
=======================

![Nuget](https://img.shields.io/nuget/v/argsentry)
![Nuget](https://img.shields.io/nuget/dt/argsentry)

[![Build status](https://ci.appveyor.com/api/projects/status/yxa3tt4d9exdhgik?svg=true)](https://ci.appveyor.com/project/eric-davis/argsentry)
[![codecov](https://codecov.io/gh/eric-davis/ArgSentry/branch/master/graph/badge.svg)](https://codecov.io/gh/eric-davis/ArgSentry)

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