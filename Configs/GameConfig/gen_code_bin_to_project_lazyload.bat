Cd /d %~dp0
echo %CD%

set WORKSPACE=../..
set LUBAN_DLL=%WORKSPACE%\Tools\Luban\LubanDll\Luban.dll
set CONF_ROOT=.
set DATA_OUTPATH=%WORKSPACE%/Unity/Assets/GameRes/Configs/
set CODE_OUTPATH=%WORKSPACE%/Unity/Assets/GameScripts/Hotfix/GameProto/GameConfig/

xcopy /s /e /i /y "%CONF_ROOT%\CustomTemplate\LubanComponent.cs" "%WORKSPACE%\Unity\Assets\GameScripts\Hotfix\GameProto\LubanComponent.cs"

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d bin^
    --conf %CONF_ROOT%\luban.conf ^
    --customTemplateDir %CONF_ROOT%\CustomTemplate\CustomTemplate_Client_LazyLoad ^
    -x outputCodeDir=%CODE_OUTPATH% ^
    -x outputDataDir=%DATA_OUTPATH% 
pause

