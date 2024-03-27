# license.licx Painkiller
Dieser MsBuild Task erstellt vor dem build eine leere `license.licx`, falls diese benötigt aber nicht vorhanden ist.

Siehe: https://community.devexpress.com/blogs/ctodx/archive/2009/03/06/licenses-licx-file-woes.aspx

## Verwendung
Durch die Installation des NuGet-Package wird automatisch der MsBuild-Task `CreateEmptyLicense` zum Projekt hinzugefügt, welcher prüft ob das Projekt eine `license.licx` verwendet. Wenn diese Datei benötigt wird aber keine vorhanden ist, erstellt der Build-Task automatisch eine leere Datei unter `Resources\license.licx`.
