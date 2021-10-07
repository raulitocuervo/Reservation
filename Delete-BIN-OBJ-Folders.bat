@echo off
@echo Deleting all BIN and OBJ folders…
d:
cd\Work\Proyectos\28 EVA\Eva Blazor\EVA
for /d /r . %%d in (bin,obj) do @if exist "%%d" echo s| rd /s "%%d"
@echo BIN and OBJ folders successfully deleted :) Close the window.
pause > nul