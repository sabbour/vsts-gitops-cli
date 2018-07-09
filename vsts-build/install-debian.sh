#!/bin/bash

curl -Lo "$SYSTEM_DEFAULYWORKINGDIRECTORY/vsts-gitops-cli.zip" "https://aka.ms/vsts-gitops-debian-dev"
unzip -d "$SYSTEM_DEFAULYWORKINGDIRECTORY/vsts-gitops-cli" "$SYSTEM_DEFAULYWORKINGDIRECTORY/vsts-gitops-cli.zip"
chmod +x "$SYSTEM_DEFAULYWORKINGDIRECTORY/vsts-gitops-cli/vsts-gitops-cli"
updated_path=$PATH:"$SYSTEM_DEFAULYWORKINGDIRECTORY/vsts-gitops-cli/"
echo "##vso[task.setvariable variable=PATH]$(echo $updated_path)"