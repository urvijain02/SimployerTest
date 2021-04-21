# TopicTweets

### How to run
1. Git clone this repo
2. Open Twitter developer account and retrieve **Bearer Token**
3. Edit ```TopicTweets\appsettings.json``` to update the **BearerToken** to value obtained in step 2
4. Compile and Run

### Deploying on IIS
1. Install [.Net Core hosting bundle](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-5.0&tabs=visual-studio)
2. Publish application ```dotnet publish --configuration Release``` or Publish to folder via Visual studio
3. Create Application pool with
    1. .Net clr version set to *No managed code*
    2. Identity set to user with write privilages
4. Create Website and select folder with published content
5. Navigate to http[s]://webserver[:port]/swagger/index.html

### 405 - Method not allowed on Delete on IIS
If you are facing Method not allowed error while calling Delete APIs after deploying on IIS, modify web.config to remove WebDAV Module from the app.
```
<system.webServer>
  <modules>
    <remove name="WebDAVModule" />
  </modules>
  <handlers>
    <remove name="WebDAV" /> 
    <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
  </handlers>
  <aspNetCore processPath="dotnet" arguments=".\TopicTweets.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess" />
</system.webServer>
```
