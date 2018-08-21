# Event Grid Proxy

## Description

This Azure function is a quick sample to test EventGrid web-hooks.

The function was written in VSCode.

## Building

1. Open the function in vscode
1. VSCode will detect the function using the project file and will ask you to download the dependencies.
1. To build the solution use <CTRL+SHIFT+P> and select "Task: Run Build Task" or <CTRL+SHIFT+B>

## Deployng

1. To deploy the function use <CTRL+SHIFT+P> and select "Deploy to Function App...".  Make sure your function is anonymous

## Usage

Point your browser to your endpoint or if you are in the command execute:

``` bash
https://<your function app>.azurewebsites.net/api/eventgrid
```

# Logs

Start the Azure Function streaming logs to observe if there are any errors. If sucessful deployment logs should have something like this:

```
2018-08-21T02:48:51.916 [Information] Executing 'eventgrid' (Reason='This function was programmatically called via the host APIs.', Id=a3f7e15f-...-ecff2a003901)

2018-08-21T02:48:51.917 [Information] C# HTTP trigger function processed a request.

2018-08-21T02:48:51.919 [Information] Executed 'eventgrid' (Succeeded, Id=a3f7e15f-...-ecff2a003901)
```

