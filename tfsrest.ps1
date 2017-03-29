Param(
   [string]$tfsUrl = "https://autotest1.VisualStudio.com/",
   [string]$collectionName = 'DefaultCollection',
   [string]$collectionUrl =  "$($tfsUrl)$($collectionName)",
   [string]$user = "gytis@4teamcorp.com",
   [string]$token = "xgzht4z34lvxmxmrlheyae2ibd2aqedjcjtcq32rcayzpgudy4ea",
   [string]$getProjectsUrl = "$($collectionUrl)/_apis/projects?api-version=2.0"
)
 
# Base64-encodes the Personal Access Token (PAT) appropriately
$base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(("{0}:{1}" -f $user,$token)))


$result = Invoke-RestMethod -Uri $getProjectsUrl -Method Get -ContentType "application/json" -Headers @{Authorization=("Basic {0}" -f $base64AuthInfo)}

Write-Output $result