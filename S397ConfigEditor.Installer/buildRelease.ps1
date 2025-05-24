using namespace System.Management.Automation.Host
Add-Type -AssemblyName PresentationFramework

function UpdateGUID 
{
    $file = $PSScriptRoot + '\Product.wxs'
    $content = Get-Content -Path $file
    $guid = [guid]::NewGuid().ToString().ToUpper()
    Write-Output $guid
    $replace = 'ProductCode = {' + $guid + '}'
    $newContent = $content -replace 'ProductCode *= *\{.*\}', $replace
    $newContent | Set-Content -Path $file

    $msgBoxInput =  [System.Windows.MessageBox]::Show('Change the version string in AssemblyVersion?','Version update','YesNo','Question')

    switch  ($msgBoxInput) {
        'Yes'
        {
            $file = $PSScriptRoot + '\..\Properties\AssemblyInfo.cs'
            Start-Process -Wait notepad $file
            
            $file = $PSScriptRoot + '\..\Properties\version.txt'
            #Start-Process -Wait notepad $file
            
            $file = $PSScriptRoot + '\..\..\auto_update_data_files\primary\auto_update_data.xml'
            Start-Process -Wait notepad $file
            
            $file = $PSScriptRoot + '\..\..\auto_update_data_files\secondary\auto_update_data.xml'
            Start-Process -Wait notepad $file
            
            $file = $PSScriptRoot + '\..\..\auto_update_data_files\gitlab\auto_update_data.xml'
            if (Test-Path -Path $file) {
                 Write-Output "Edit the https://gitlab.com/mr_belowski/CrewChiefV4/-/raw/main/CrewChiefV4_installer/Installs/CrewChiefV4- line too!"
                 Start-Process -Wait notepad $file
            }
        }
    }       
}

function BuildRelease 
{
    # Set the path environment variable to include MSBuild
    $env:Path += ";C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin"

    # Change directory to project root
    $path = $PSScriptRoot + "\.."
    Set-Location -Path $path

    # Build S397ConfigEditor.csproj with Release configuration
    Write-Output "Building..."
    $ErrorsLine = (msbuild S397ConfigEditor.csproj /t:Rebuild /p:Configuration=Release) | Select-String "Error\(s\)"
    if (!$ErrorsLine -contains " 0 Error")
    {
    	Write-Output $ErrorsLine
        #[System.Windows.MessageBox]::Show($ErrorsLine,'Errors in build','Quit','OK')
        exit
    }
}
function BuildInstaller
{
    # Insert the version info in the .exe
    $file = $PSScriptRoot + '\..\Properties\version.txt'
    $exe = $PSScriptRoot + '\..\bin\Release\S397ConfigEditor.exe'
    #Gets overwritten by Wix??? pyi-set_version.exe $file $exe


    # Change directory to S397ConfigEditor.installer
    $path = $PSScriptRoot # + "\..\..\S397ConfigEditor.installer"
    Set-Location -Path $path

    # Build S397ConfigEditor.installer.wixproj with Release configuration
    Write-Output "Building installer..."
    $Log = (msbuild S397ConfigEditor.installer.wixproj /t:Rebuild /p:Configuration=Release)
    Set-Content -Path "WixLog.txt" -Value $Log
}

function Success
{
    [System.Windows.MessageBox]::Show('Built successfully','S397ConfigEditor Build Menu','OK','Information')
}
#######################################################################################


#UpdateGUID
BuildRelease
BuildInstaller
Success
