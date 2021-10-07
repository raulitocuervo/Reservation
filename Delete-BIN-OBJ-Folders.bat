@echo off
@echo Deleting all BIN and OBJ folders…
d:
cd\Documentos\En Proceso\IsuCorp\Reservation
for /d /r . %%d in (bin,obj) do @if exist "%%d" echo s| rd /s "%%d"
@echo BIN and OBJ folders successfully deleted :) Close the window.
pause > nul