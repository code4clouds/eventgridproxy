# Event Grid Proxy

## Description

This function provides a proxy to another server.  The idea is to pass the messages received to another server.  I build this function to test the event grid webhook features given test to the webhook needs to be sent to a valid SSL endpoint.

The function was written in VSCode.

## Building

1. Open the function in vscode
1. VSCode will detect the function using the project file and will ask you to download the dependencies.
1. To build the solution use <CTRL+SHIFT+P> and select "Task: Run Build Task" or <CTRL+SHIFT+B>

## Deployng

1. To deploy the function use <CTRL+SHIFT+P> and select "Deploy to Function App..."

## Usage

Point your browser to your endpoint or if you are in the command execute:

``` bash
https://<your function app url>/api/HttpTriggerCSharp?name=somenamehere&url=http://somenonssllistener.com
```

## Parameters

| Parameter | Description |
| --- | ---- |
| name | The name of the user or service.  This is useful when sharing a single non-ssl listener server. |
| url | The url of the listener server to forward the request | 
