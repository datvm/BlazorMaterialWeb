$files=get-childitem -r | where {$_.Name -like "*.nupkg" -and $_.Name -notlike "*symbols*"}

foreach($file in $files) {
	rm $file.FullName
}

$version="--property:Version=2.1.0.0"

dotnet pack .\BlazorMaterialWeb\BlazorMaterialWeb.csproj -c Release "--property:PackageOutputPath=.\bin\nuget" "$version"
dotnet pack .\BlazorMaterialWeb.Bundled\BlazorMaterialWeb.Bundled.csproj -c Release "--property:PackageOutputPath=.\bin\nuget" "$version"