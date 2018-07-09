#!/bin/bash

echo "Source: $1"
echo "Destination: https://$2.blob.core.windows.net/$3/$4"

azcopy --source $1 --destination https://$2.blob.core.windows.net/$3/$4 --dest-key $5 --verbose --quiet