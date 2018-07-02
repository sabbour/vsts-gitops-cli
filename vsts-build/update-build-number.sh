#!/bin/bash

# Get a short Git commit ID
short_commit_id=${BUILD_SOURCEVERSION:0:7}

if [ "$BUILD_REASON" = "PullRequest" ]; then
  custom_build_tag=$BUILD_SOURCEBRANCHNAME-pr-$SYSTEM_PULLREQUEST_PULLREQUESTNUMBER-$BUILD_BUILDID-$short_commit_id
else
  custom_build_tag=$BUILD_SOURCEBRANCHNAME-$BUILD_BUILDID-$short_commit_id
fi

# Convert to lowercase
custom_build_tag=$(echo "$custom_build_tag" | tr '[:upper:]' '[:lower:]')

# Update build number in VSTS
echo "##vso[build.updatebuildnumber]$(echo $custom_build_tag)"