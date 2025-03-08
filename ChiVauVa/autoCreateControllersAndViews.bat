@echo off
setlocal enabledelayedexpansion

set models=User Role Supplier Part PriceHistory Customer Employee Order OrderDetail Delivery

for %%m in (%models%) do (
    echo Generating %%mController...
    dotnet aspnet-codegenerator controller -name "%%mController" -m %%m -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
    if errorlevel 1 (
        echo Ошибка при генерации %%mController
        exit /b 1
    )
)

echo Все контроллеры успешно созданы!
pause