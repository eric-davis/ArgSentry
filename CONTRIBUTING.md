# Contributing

## Branching and Pull Requests

This project uses a trunk-based development model. `master` is the only long-lived branch.

1. Create a short-lived feature branch off `master`.
2. Open a Pull Request targeting `master`.
3. The `CI` workflow (`build-test` job) must pass.
4. Merges must result in linear history. Use squash or rebase merges.

## Releases

Releases are fully automated.

* **Prereleases:** Every merge to `master` triggers the `release.yml` workflow, which publishes a prerelease NuGet package (e.g., `3.1.0-preview.0.7`). No action is required from contributors.
* **Stable Releases:** The maintainer cuts stable releases by pushing an annotated git tag matching `vX.Y.Z` (e.g. `git tag -a v3.1.0 -m "v3.1.0" && git push origin v3.1.0`). This builds a clean `X.Y.Z` package, publishes it to NuGet, and creates a GitHub Release with auto-generated notes.

## Versioning

Versioning is handled automatically via [MinVer](https://github.com/adamralph/minver) based on git tags.

* Do not manually edit `AssemblyVersion`, `FileVersion`, or `InformationalVersion` in the `.csproj` file.
* Version numbers are derived from the latest git tag.

## Local Development

To build and test the project locally:

```bash
dotnet build
dotnet test
```
