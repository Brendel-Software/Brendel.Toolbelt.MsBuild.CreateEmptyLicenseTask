using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Brendel.Toolbelt.MsBuild.CreateEmptyLicenseTask;

public class CreateEmptyLicenseTask : Task {
	public string ProjectPath { get; set; } = string.Empty;

	public override bool Execute() {
		if (string.IsNullOrWhiteSpace(ProjectPath)) {
			Log.LogError("ProjectPath is not set");
			return false;
		}

		var projectDir = Path.GetDirectoryName(ProjectPath)!;
		var licenseDir = Path.GetFullPath(Path.Combine(projectDir, "Properties"));
		var licenseFile = Path.GetFullPath(Path.Combine(licenseDir, "licenses.licx"));

		if (File.Exists(licenseFile)) {
			return true;
		}

		try {
			if (CheckProjectIncludesLicenseFile(ProjectPath)) {
				CreateEmptyFile(licenseFile);
				Log.LogMessage(MessageImportance.High, "{0} -> created empty license.licx on {1}", nameof(CreateEmptyLicenseTask), licenseDir);
			} else {
				Log.LogMessage(MessageImportance.High, "{0} -> skipped creation of license file", nameof(CreateEmptyLicenseTask));
			}
			return true;
		} catch (Exception ex) {
			Log.LogError("Failed to create file {0}: {1}", licenseFile, ex.Message);
			return false;
		}
	}

	private static void CreateEmptyFile(string file) {
		var dir = Path.GetDirectoryName(file)!;
		if (!Directory.Exists(dir)) {
			Directory.CreateDirectory(dir);
		}

		new FileStream(file, FileMode.CreateNew, FileAccess.Write, FileShare.Read).Dispose();
	}

	private static bool CheckProjectIncludesLicenseFile(string projectFilePath) {
		var xml = XDocument.Load(projectFilePath);
		return xml.Descendants()
		   .Select(element => element.Attribute("Include"))
		   .Select(attr => attr?.Value)
		   .Any(val => val == @"Properties\licenses.licx");
	}
}