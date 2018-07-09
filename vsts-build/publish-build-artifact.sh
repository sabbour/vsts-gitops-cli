#!/bin/bash

azcopy \
    --source $1 \
    --destination https://$2.blob.core.windows.net/$3/$4 \
    --dest-key $5