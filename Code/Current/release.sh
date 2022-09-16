#!/bin/bash

dotnet publish -c release
rm -rf /C/Programs/QikConsole/*
cp -rf QikConsole/bin/Release/net6.0/publish/* /C/Programs/QikConsole/
