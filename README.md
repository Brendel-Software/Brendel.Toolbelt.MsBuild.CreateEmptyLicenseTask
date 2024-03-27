[![Build Status](https://dev.azure.com/brendel-storage/R%C3%BCdigers%20Spielwiese/_apis/build/status%2FBrendel.Toolbelt.MsBuild.CreateEmptyLicenseTask?branchName=master)](https://dev.azure.com/brendel-storage/R%C3%BCdigers%20Spielwiese/_build?definitionId=37)

# CreateEmptyLicenseTask
This MsBuild Task creates an empty `license.licx` before the build if it is needed but not present.

Background information see: [DevExpress Blog Entry](https://community.devexpress.com/blogs/ctodx/archive/2009/03/06/licenses-licx-file-woes.aspx)

## Usage
By installing the NuGet package, an MsBuild Task named `CreateEmptyLicense` is automatically added to the project, which checks if the project uses a `license.licx`. If this file is needed but not present, the build task automatically creates an empty file under `$(ProjectDir)\Resources\license.licx`.
