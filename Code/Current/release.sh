#!/bin/bash

dotnet publish -c release
rm -rf /C/Program\ Files/Qik/*
cp -rf QikConsole/bin/Release/net7.0/publish/* /C/Program\ Files/Qik/
