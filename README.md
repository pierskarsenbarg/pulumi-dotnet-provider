# Demo Pulumi provider built in .NET

## Intro

This is a Pulumi provider built using .NET, for demo purposes

## Pre-Requisites

You must have the following installed:

- [Pulumi CLI](https://www.pulumi.com/docs/get-started/install/)
- [.NET Core](https://dotnet.microsoft.com/en-us/download) (minimum 6.0)
- [NodeJS](https://nodejs.org/en) (for the example)

## Build instructions

1. Build - `dotnet build`
1. Add the bin folder to your path - `export PATH=$PATH:$PWD/src/bin/Debug/net6.0`
1. Generate NodeJS SDK from schema.json - `pulumi package gen-sdk --language nodejs --out sdk ./schema.json`
1. Install node packages in the SDK folder and run npm link - `cd sdk/nodejs && npm i && npm link`
1. Go to examples folder and run npm link in the example - `cd ../../example/provider-test && npm i && npm link @pulumi/myprovider`
1. Run update - `pulumi up`