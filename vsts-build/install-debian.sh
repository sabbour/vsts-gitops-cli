#!/bin/bash

curl -Lo $(System.DefaultWorkingDirectory)/vsts-gitops-cli.zip "https://aka.ms/vsts-gitops-debian-$(lowercase_branch)"
unzip -d $(System.DefaultWorkingDirectory)/vsts-gitops-cli $(System.DefaultWorkingDirectory)/vsts-gitops-cli.zip
chmod +x $(System.DefaultWorkingDirectory)/vsts-gitops-cli/vsts-gitops-cli
updated_path=$PATH:$(System.DefaultWorkingDirectory)/vsts-gitops-cli/
echo "##vso[task.setvariable variable=PATH]$(echo $updated_path)"