# Foodie

# Git

## Branches and Issues

In this project there are only two types of branches:
- ___feature___
- ___fix___

Feature has to be connected with one Issue. Fix branch may or may not be connected with issue.

__Conventions__:
- __only__ english words
- __only__ lowercase letters
- branch name always starts with: ___feature/___ or ___fix/___
- use a __dash__ instead of space
- better when name of the branch is the same as issue name

__Example__:
- issue name: ___Setup backend project___
- branch name: ___feature/setup-backend-project___

## Merge Requests

Merge request is created after we finish some ___feature___ or ___fix___ branch.

__Conventions__:
- include source branch name and destination branch name
- has structure: ___<srcBranch<srcBranch>> to <dstBranch<dstBranch>>___

__Example__:
- source branch name: ___feature/setup-backend-project___
- destination branch name: ___master___
- merge request name: ___<feature/setup-backend-project> to <master<master>>___

# Server installation and startup

Firstly you need to install dotnet sdk (version 3.1.102) on your computer. You will find this in the link below:

-    https://dotnet.microsoft.com/download/dotnet-core/3.1

Second step is two run the app in your favourite IDE or terminal. Personally I recommend to use Visual Studio Code with C# extension. Click run button in VS Code, and after this you can start consume data from WebAPI.

To use PDF feature download these files depending on your Windows version and paste them into directory yourProjectDirectory/RestApi/RestApi
-    https://github.com/rdvojmoc/DinkToPdf/tree/master/v0.12.4

# Data

## Scheme

Simplified models scheme is located at the link below

- [Lucidchart - models scheme](https://www.lucidchart.com/documents/edit/04b16a51-ad16-40c7-b5e7-e475f84db815/0_0?beaconFlowId=39C9DE45C870A24E#?folder_id=home&browser=icon)

## Databases

## Postman

Postman enviroment and collections can be found under this [link](https://drive.google.com/drive/folders/1kqTOrs3lhXW_7B91K80VssgXp7mss6k1?fbclid=IwAR1qPSTWKH-C6JwwgW2zzO3FZodlS_mhAyTNlPHDq6q9er8A65_jgtDKthU).
