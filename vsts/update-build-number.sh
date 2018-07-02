#!/bin/bash

# Get a short Git commit ID
short_commit_id=${BUILD_SOURCEVERSION:0:7}

# If this is from a pull request, add the PR number, otherwise, don't
if [ -z "$SYSTEM_PULLREQUEST_PULLREQUESTNUMBER"] 
then
  echo "not from pull request";
  custom_build_tag=$BUILD_SOURCEBRANCHNAME-$BUILD_REASON-$short_commit_id-$BUILD_BUILDID
else
  echo "from pull request number $SYSTEM_PULLREQUEST_PULLREQUESTNUMBER";
  custom_build_tag=$BUILD_SOURCEBRANCHNAME-$BUILD_REASON-$SYSTEM_PULLREQUEST_PULLREQUESTNUMBER-$short_commit_id-$BUILD_BUILDID
fi

# Convert to lowercase
custom_build_tag=$(echo "$custom_build_tag" | tr '[:upper:]' '[:lower:]')

# Update build number in VSTS
echo "##vso[build.updatebuildnumber]$(echo $custom_build_tag)"