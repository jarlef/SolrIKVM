@echo off
set ikvmc="..\ikvm\ikvmc.exe"
set ikvm="..\ikvm"
cd lib
%ikvmc% -out:solr.dll -target:library ..\jars\solr36\*.jar
cd ..
msbuild