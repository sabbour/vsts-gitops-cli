# VSTS GitOps CLI

## Building

**Windows:**

```sh
dotnet build -c release
dotnet publish -r win10-x64 -c release
```

**Mac OS:**

```sh
dotnet build -c release
dotnet publish -r osx.10.12-x64 -c release
```

**Debian:**

```sh
dotnet build -c release
dotnet publish -r debian.8-x64 -c release
```

## Running

Change directory to where the files were published, for example

```sh
cd bin/release/netcoreapp2.0/<runtime>/publish/
```

Then run

```sh
./vsts-gitops
```