# Dex_Data_AutoReLoad

<div align='center'>
<img src='requirements.png'><br>
<img src='image.png'><br>
Releases : <a href = 'https://github.com/pozuhtuhv/Dex_DataLoad/releases/tag/v0.1'>Download</a>
</div>

0. **Timer Set**
   - Edit -> 'Dex_DataLoad.cs' File Open.
   - 32Lines -> **System.Timers.Timer\(xx\)\;** -> 'xx' Edit (1000 = 1sec) -> Save
   - Run and Rebuild ('dotnet publish' command)

0. **Code Compile**  
```bash
dotnet publish --configuration Release
```
```bash
bin/Release/netx.0/publish/xxx.exe
```
\* official Docs : 
Check orders paid for of token (rate-limit 60 requests per minute)

<br>

**The API data is officially provided by Dexscreener but may still differ; please verify independently.**
