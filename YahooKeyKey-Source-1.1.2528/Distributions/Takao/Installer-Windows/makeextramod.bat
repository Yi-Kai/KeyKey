if exist setup.exe (del setup.exe)
msbuild /target:Bootstrapper extramod.proj
iexpress /N ExtraModules.sed 
