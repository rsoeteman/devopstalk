# DevOps talk
Repository where you can download the samples and find some info from my DevOps talk.

# GitVersion
GitVersion is a tool that generates a Semantic Version number based on your Git history. The version number generated from GitVersion can then be used in your assemblies, NuGet packages and all of this can be done from your build Pipeline (or locally if you want). 
https://gitversion.net/ 

All available variables can be found here: https://gitversion.net/docs/reference/variables

# Umbraco references
The talk contained a few Umbraco related topics. 

## Umbraco Unattended Install
Unattended install is a way to install Umbraco without the need of a user. This can be used in a powershell script.
https://docs.umbraco.com/umbraco-cms/fundamentals/setup/install/unattended-install 

## Migrations
Migrations are a way to update your Umbraco Environment. Migrations will be executed once when it not already ran in your Umbraco solution and can modify your Umbraco install from code.
https://docs.umbraco.com/umbraco-cms/extending/packages/creating-a-package#custom-package-migration

## Manifest filter
Since we are using a service for retrieving version information we use a manifest filter instead of manifest file in our package.
https://docs.umbraco.com/umbraco-cms/extending/property-editors/package-manifest 

# Devops marketplace extensions

All extensions for devops can be found at https://marketplace.visualstudio.com/azuredevops

## GitVersion
Extension to use GitVersion in your build pipeline.
https://marketplace.visualstudio.com/items?itemName=GitVersion.gitversion-preview

## Assembly info task
Assembly Info is an extension for Azure DevOps that populates assembly information metadata from a build pipeline.
https://marketplace.visualstudio.com/items?itemName=bleddynrichards.Assembly-Info-Task