@echo off
set ikvmc="..\ikvm\ikvmc.exe"
set ikvm="..\ikvm"
cd lib
%ikvmc% -out:solr.dll -target:library ..\jars\solr35\*.jar
msbuild