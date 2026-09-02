## Setting up the environment

To set up the repository, run:

```sh
$ dotnet restore
$ dotnet build
```

This will install required dependencies and build the SDK.

## Modifying/Adding code

Most of this SDK is generated. Edits to generated files are overwritten the next time the SDK is
regenerated, so changes belong either in the OpenAPI document and SDK config the generator reads, or
in hand-written files the generator does not emit — regeneration only rewrites the files it emits,
and never deletes the rest. The generator will never modify the contents of the `examples/` directory.

## Using the repository from source

To use a local version of this library from source in another project, add it using a directory reference:

```sh
$ dotnet add reference /path/to/sdk/src/Straddle
```

## Formatting and linting

```sh
$ dotnet tool restore
$ dotnet csharpier format .
```

## Running tests

```sh
$ dotnet test
```
