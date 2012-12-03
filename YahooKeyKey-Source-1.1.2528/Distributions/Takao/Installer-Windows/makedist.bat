@echo off
echo == obfuscating the modules
call obfuscate.bat

echo == packaging MSI
if exist *.wixobj (del *.wixobj)
if exist ..\..\..\release\*.msi (del ..\..\..\release\*.msi)

set VERSION=1.1.2528
set EXTRAMOD=..\..\..\release\extramod.msi
set W32MSI=..\..\..\release\ykeykey.msi
set W64MSI=..\..\..\release\keykey64.msi

"C:\Program Files\Windows Installer XML\bin\candle" ExtraModules.wxs -out ExtraModules.wixobj
"C:\Program Files\Windows Installer XML\bin\light" ExtraModules.wixobj -out %EXTRAMOD%  "C:\Program Files\Windows Installer XML\bin\wixui.wixlib" -loc "wixui_zh-tw.wxl"

"C:\Program Files\Windows Installer XML\bin\candle" Installer.wxs -out Installer.wixobj
"C:\Program Files\Windows Installer XML\bin\light" Installer.wixobj -out %W32MSI%  "C:\Program Files\Windows Installer XML\bin\wixui.wixlib" -loc "wixui_zh-tw.wxl"

"C:\Program Files\Windows Installer XML\bin\candle" Installer64.wxs -out Installer64.wixobj
"C:\Program Files\Windows Installer XML\bin\light" Installer64.wixobj -out %W64MSI%  "C:\Program Files\Windows Installer XML\bin\wixui.wixlib" -loc "wixui_zh-tw.wxl"

echo == Making setup exe's
call makesetup
call makesetup64
call makesupplement
call makeextramod
