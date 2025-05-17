chcp 65001
set LUBAN_DLL=Luban/Luban.dll
set CONF_ROOT=..\Profile\Excel

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d bin  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=..\Unity\Assets\Scripts\Model\Generate\Client\Config ^
    -x outputDataDir=..\Config\Excel\c

dotnet %LUBAN_DLL% ^
    -t server ^
    -c cs-bin ^
    -d bin  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=..\Unity\Assets\Scripts\Model\Generate\Server\Config ^
    -x outputDataDir=..\Config\Excel\s

dotnet %LUBAN_DLL% ^
    -t all ^
    -c cs-bin ^
    -d bin  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=..\Unity\Assets\Scripts\Model\Generate\ClientServer\Config ^
    -x outputDataDir=..\Config\Excel\cs

xcopy /y ..\Config\Excel\cs ..\Unity\Assets\Bundles\Config /E /I

pause