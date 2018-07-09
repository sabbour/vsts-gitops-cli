# VSTS GitOps CLI

## Building

**Windows:**

```sh
dotnet publish -r win10-x64 -c release
```

**Mac OS:**

```sh
dotnet publish -r osx.10.12-x64 -c release
```

**Debian:**

```sh
dotnet publish -r debian.8-x64 -c release
```

## Running

Change directory to where the files were published, for example

```sh
cd bin/release/netcoreapp2.0/<runtime>/publish/
```

Then run

```sh
./vsts-gitops-cli -v
```

## Downloading

The latest built versions (from development branch) are available at:

- **Windows:** [https://aka.ms/vsts-gitops-win-dev](https://aka.ms/vsts-gitops-win-dev)
- **Mac OS:** [https://aka.ms/vsts-gitops-osx-dev](https://aka.ms/vsts-gitops-osx-dev)
- **Debian:** [https://aka.ms/vsts-gitops-debian-dev](https://aka.ms/vsts-gitops-debian-dev)

# Using the task

- On a Hosted Linux Agent, create a Bash task with the following inline script

  ```sh
  curl -Lo install-vsts-gitops.sh https://aka.ms/install-vsts-gitops-debian \
  && chmod +x install-vsts-gitops.sh \
  && ./install-vsts-gitops.sh
  ```