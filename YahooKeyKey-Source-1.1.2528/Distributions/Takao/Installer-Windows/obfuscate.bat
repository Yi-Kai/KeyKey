@echo off
if exist "\Program Files\Wise Owl Consulting LLC\Demeanor for .NET, Enterprise Edition\v4.0\Demeanor.exe" goto obf

:nobf
rmdir /s/q ..\..\..\release\obfuscated
mkdir ..\..\..\release\obfuscated
mkdir ..\..\..\release\obfuscated\zh-TW
mkdir ..\..\..\release\obfuscated\zh-CN

copy ..\..\..\release\KeyKeyServer.exe ..\..\..\release\obfuscated\
copy ..\..\..\release\KeyKeyUI.DLL ..\..\..\release\obfuscated\
copy ..\..\..\release\Preference.DLL ..\..\..\release\obfuscated\
copy ..\..\..\release\ServiceUI.exe ..\..\..\release\obfuscated\
copy ..\..\..\release\QuickSetup.exe ..\..\..\release\obfuscated\
copy ..\..\..\release\PreferencesMain.exe ..\..\..\release\obfuscated\
copy ..\..\..\release\PhraseEditor.exe ..\..\..\release\obfuscated\
copy ..\..\..\release\CinInstaller.exe ..\..\..\release\obfuscated\
copy ..\..\..\release\zh-TW\*.* ..\..\..\release\obfuscated\zh-TW\
copy ..\..\..\release\zh-CN\*.* ..\..\..\release\obfuscated\zh-CN\

goto eob

:obf
echo obfuscating files
del ..\..\..\release\*.xml
rmdir /s/q ..\..\..\release\obfuscated
"\Program Files\Wise Owl Consulting LLC\Demeanor for .NET, Enterprise Edition\v4.0\Demeanor.exe" /es /out:..\..\..\release\obfuscated /r:..\..\..\release\Demeanor.xml /sa /app ..\..\..\release\KeyKeyServer.exe
"\Program Files\Wise Owl Consulting LLC\Demeanor for .NET, Enterprise Edition\v4.0\Demeanor.exe" /es /out:..\..\..\release\obfuscated /c:..\..\..\release\Demeanor.xml /sa ..\..\..\release\ServiceUI.exe
"\Program Files\Wise Owl Consulting LLC\Demeanor for .NET, Enterprise Edition\v4.0\Demeanor.exe" /es /out:..\..\..\release\obfuscated /c:..\..\..\release\Demeanor.xml /sa ..\..\..\release\QuickSetup.exe
"\Program Files\Wise Owl Consulting LLC\Demeanor for .NET, Enterprise Edition\v4.0\Demeanor.exe" /es /out:..\..\..\release\obfuscated /c:..\..\..\release\Demeanor.xml /sa ..\..\..\release\PreferencesMain.exe
"\Program Files\Wise Owl Consulting LLC\Demeanor for .NET, Enterprise Edition\v4.0\Demeanor.exe" /es /out:..\..\..\release\obfuscated /c:..\..\..\release\Demeanor.xml /sa ..\..\..\release\PhraseEditor.exe
"\Program Files\Wise Owl Consulting LLC\Demeanor for .NET, Enterprise Edition\v4.0\Demeanor.exe" /es /out:..\..\..\release\obfuscated /c:..\..\..\release\Demeanor.xml /sa ..\..\..\release\CinInstaller.exe

:eob
echo binary prepared
